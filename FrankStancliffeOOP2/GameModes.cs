using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FrankStancliffeOOP2
{
    /// <summary>
    /// this class holds methods representing each game mode
    /// </summary>
    internal class GameModes
    {
        private Statistics statistics;
        public GameModes(Statistics statistics)
        {
            this.statistics = statistics;
        }

        // RULES FOR REFERENCE 
        // 5 x dice
        //Rules:
        //Roll all 5 dice hoping for a 3-of-a-kind or better.
        //	If 2-of-a-kind is rolled, player may choose to rethrow all, or the remaining dice.
        //	3-of-a-kind: 3 points
        //	4-of-a-kind: 6 points
        //	5-of-a-kind: 12 points
        //    First to a total of 20.


        /// <summary>
        /// rolls 5 die for each player, finds the biggest nu 
        /// </summary>
        /// <param name="points">array holding int values for each players current point count</param>
        /// <returns>array for number of points each player holds</returns>
        public int[] ThreeOrMore(int[] points, int partnerChoice)
        {
            int[] turns = {0,0};
            int[] gamePoints = { 0, 0 };
            for ( int i2 = 0; i2 < 3; i2++)
            {
                if (i2 == 2) { i2 = 0; } // esnures a loop while keeping value betweeen 0 and 1
                turns[i2]++;

                int turn = i2;
                Console.WriteLine("");
                if (partnerChoice == 1 && turn == 1) { Console.WriteLine("Computers Turn"); }
                else { Console.WriteLine("Player {0}'s Turn :", (turn + 1)); Console.ReadLine(); }
                Testing testing = new Testing();
                int[] scores = { 3, 6, 12 }; // scores to be added dependant 3,4,5 repeated die
                int rolled = 0;
                while (rolled != 1)
                {
                    int[] arrayOfDieRolls = Roll5Die();
                    //
                    foreach (int item in arrayOfDieRolls) { Console.WriteLine(item); }
                    //
                    int[] biggestOfAKind = checkForMultiples(arrayOfDieRolls); // checks for any matching values, should return most common match

                    Console.WriteLine("\nBiggest of a kind {0} {1}s \n", biggestOfAKind[0], biggestOfAKind[1]);
                    if (biggestOfAKind[0] == 2)
                    {
                        int reRollAll = 0;
                        if (partnerChoice == 1 && turn == 1) { Console.WriteLine("Computer ReRolled Remaining Die"); reRollAll = 1; }
                        else
                        {
                            string[] arrayChoices = { "Re-Roll All", "Re-Roll Remaining 3 Die" };
                            reRollAll = testing.Checker("Rolled 2 of-a-kind, ReRoll all or just the other remaining 3 die?:", arrayChoices);
                        }
                        if (reRollAll == 1)
                        {
                            arrayOfDieRolls = ReRollRemainingDie(arrayOfDieRolls, biggestOfAKind[1]); // method accepts the array of die and the value of the repeated die 
                        }   // then re rolls all die not equaal to the value of original repeated die
                        else { arrayOfDieRolls = Roll5Die(); }
                        biggestOfAKind = checkForMultiples(arrayOfDieRolls);
                        Console.WriteLine("\n New biggest of a kind {0} {1}s ({2}{3}{4}{5}{6})\n", biggestOfAKind[0], biggestOfAKind[1], arrayOfDieRolls[0], arrayOfDieRolls[1], arrayOfDieRolls[2], arrayOfDieRolls[3], arrayOfDieRolls[4]);
                    }
                    rolled = 1; 
                    if (biggestOfAKind[0] > 2) // to ensure error not encountered if biggest of kind[0] is less than 2 (cause negative position)
                    {
                        int pointToAdd = scores[(biggestOfAKind[0] - 3)];
                        gamePoints[turn] += pointToAdd;
                    }
                }

                if (gamePoints[turn] > 19) {
                    int otherPlayerTurn = 0;
                    //Statistics.numberofplays.playerWin(turn);
                    if (turn == 1 && partnerChoice == 1) {
                        Console.WriteLine("Computer Won! they rolled a total of {1} in {2} turns", turn + 1, gamePoints[turn], turns[turn]);
                        Console.WriteLine("Player {0} rolled {1} in {2} turns \n", 1, gamePoints[0], turns[0]);
                    }
                    else
                    {
                        if (turn == 0) { otherPlayerTurn = 1; }
                        points[2] = gamePoints[turn];
                        Console.WriteLine("Player {0} Won! they rolled a total of {1} in {2} turns", turn + 1, gamePoints[turn], turns[turn]);
                        if (partnerChoice == 0)
                        {
                            Console.WriteLine("Player {0} rolled {1} in {2} turns \n", otherPlayerTurn + 1, gamePoints[otherPlayerTurn], turns[otherPlayerTurn]);
                        }
                        else { Console.WriteLine("Computer rolled {1} in {2} turns \n", otherPlayerTurn + 1, gamePoints[otherPlayerTurn], turns[otherPlayerTurn]); }
                    }
                    points[turn]++;
                    i2 = 4;
                }
            }
            return points;
        }  

        // RULES FOR REFERENCE
        //2 x dice
        //Rules:
        //Roll the two dice, noting the total rolled each time.
        //	If it is a 7 - stop.
        //	If it is any other number - add it to your total.
        //		If it is a double - add double the total to your score (3,3 would add 12 to your total)

        /// <summary>
        /// holds the methods and main bulk of code for the SevensOut gamemode
        /// </summary>
        /// <param name="points"> this value also returned, holding values for both player points in addition to the winning score</param>
        /// <param name="partnerChoice"> whether the user chose to play against another user or the program / computer</param>
        /// <returns></returns>
        public int[] SevensOut(int[] points, int partnerChoice) 
        {
            int turn = 0;
            int[] playersTotal = { 0, 0 };
            for (int i = 0; i<2; i++) // loop for players turns
            {
                Console.WriteLine("");
                if (partnerChoice == 1 && i == 1) { Console.WriteLine("Computer Turn:"); }
                else { Console.WriteLine("Player {0}'s Turn :", (turn + 1)); }
                int check = 0;
                while (check == 0)
                {
                    if (partnerChoice == 1 && i == 1) { Console.WriteLine(" COMPUTER ROLL: "); }
                    else { Console.WriteLine("ROLL: "); Console.ReadLine(); }
                    int[] arrayOfDieRolls = Roll2Die();
                    int totalRoll = arrayOfDieRolls[0] + arrayOfDieRolls[1];
                    Console.WriteLine("1st Roll: {0}", arrayOfDieRolls[0]);
                    Console.WriteLine("2nd Roll: {0}", arrayOfDieRolls[1]);
                    Console.WriteLine("Total: {0}", totalRoll);
                    if (totalRoll == 7 )
                    {
                        check = 1; // breaks / ends loop for players turn
                    }
                    else
                    {
                        playersTotal[turn] += totalRoll;
                    }
                }
                Console.WriteLine("Your Total:{0}",playersTotal[turn]);
                turn++;
            }
            Console.WriteLine();
            if (playersTotal[0] != playersTotal[1])
            { 
                int winner = 0;
                if (playersTotal[0] < playersTotal[1])
                {
                    winner = 1;
                }
                points[winner]++;
                points[2] = playersTotal[winner];
                if (winner == 1) { Console.WriteLine("Computer Won! ({0}:{1})", playersTotal[0], playersTotal[1]); }
                else { Console.WriteLine("Player {0} Won! ({1}:{2})", (winner + 1), playersTotal[0], playersTotal[1]); }
            }
            else {
                points[0]++; points[1]++;
                Console.WriteLine("Draw ({0}:{1}) both players gain a point :) ", playersTotal[0], playersTotal[1]);
            }
            Console.ReadLine();
            return points;
        }

        /// <summary>
        /// used in ThreeOrMore class to calculate number of matching / of-a-kind
        /// </summary>
        /// <param name="arrayOfDieRolls">array containing the rolls from the 5 die</param>
        /// <returns>array holding int value for the die face found multiple times and how many times </returns>
        public int[] checkForMultiples(int[] arrayOfDieRolls) 
        {
            int[] rollOptions = { 0, 0, 0, 0, 0, 0 }; // to hold number of times each die side has been rolled, int for each face

            for (int i = 0; i < arrayOfDieRolls.Length ; i++)
            {
                for (int j = 0; j < rollOptions.Length ; j++) // j increments from 0 to 5 representing positions in rollOptions array
                {
                    if (j+1 == arrayOfDieRolls[i]) // as positioning in array for 1 would be 0, 
                    {
                        rollOptions[j]++;
                    }
                }
            }
            int[] biggestOfAKind = { 0, 0 };
            for (int i = 0; i < rollOptions.Length; i++)
            {
                if (rollOptions[i] > biggestOfAKind[0])
                {
                    biggestOfAKind[0] = rollOptions[i];
                    biggestOfAKind[1] = i + 1;
                }
            }
            return biggestOfAKind;
        }
        /// <summary>
        /// creates 2 new die objects and rolls them
        /// </summary>
        /// <returns>array containing the two rolled values</returns>
        public int[] Roll2Die()
        {
            DieRoller die1 = new DieRoller();
            DieRoller die2 = new DieRoller();
            int[] arrayOfDieRolls = { (die1.Roll()), (die2.Roll()) };
            return arrayOfDieRolls;
        }

        /// <summary>
        /// creates 5 new die objects and rolls them
        /// </summary>
        /// <returns>array containing the five rolled die values</returns>
        public int[] Roll5Die()
        {
            DieRoller die1 = new DieRoller();
            DieRoller die2 = new DieRoller();
            DieRoller die3 = new DieRoller();
            DieRoller die4 = new DieRoller();
            DieRoller die5 = new DieRoller();
            int[] arrayOfDieRolls = { (die1.Roll()), (die2.Roll()), (die3.Roll()), (die4.Roll()), (die5.Roll()) };
            return arrayOfDieRolls;
        }
        /// <summary>
        /// this method allows the user to choose to only reroll remaining die rather than them all after rolling 2 of the same kind
        /// </summary>
        /// <param name="arrayOfDieRolls">an array of int values repersenting each dies value</param>
        /// <param name="repeatedDie">which value has been represted twice</param>
        /// <returns></returns>
        public int[] ReRollRemainingDie(int[] arrayOfDieRolls,int repeatedDie) 
        {
            DieRoller die = new DieRoller();
            int counter = 0;
            foreach (int dieRoll in arrayOfDieRolls) 
            { 
                if (dieRoll != repeatedDie) { arrayOfDieRolls[counter]=die.Roll(); }// rerolls die that are not equal to the repeated die int
                counter++;
            }
            return arrayOfDieRolls;
        }

    }
}
