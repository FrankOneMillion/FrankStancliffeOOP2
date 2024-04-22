using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace FrankStancliffeOOP2
{
    /// <summary>
    /// this class holds methods representing each game mode
    /// </summary>
    
    internal class GameModes
    {
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
        public int[] ThreeOrMore(int[] points)
        {
            int[] turns = {0,0};
            int[] gamePoints = { 0, 0 };
            for ( int i2 = 0; i2 < 3; i2++)
            {
                if (i2 == 2) { i2 = 0; }
                turns[i2]++;

                int turn = i2;
                Console.WriteLine("");
                Console.WriteLine("Player {0}'s Turn :", (turn + 1));
                Testing testing = new Testing();
                int[] scores = { 3, 6, 12 };
                int rolled = 0;
                while (rolled != 1)
                {
                    int[] arrayOfDieRolls = Roll5Die();
                    //
                    foreach (int item in arrayOfDieRolls) { Console.WriteLine(item); }
                    //
                    int[] rollOptions = checkForMultiples(arrayOfDieRolls);
                    int[] biggestOfAKind = { 0, 0 };
                    for (int i = 0; i < rollOptions.Length; i++)
                    {
                        if (rollOptions[i] > biggestOfAKind[0])
                        {
                            biggestOfAKind[0] = rollOptions[i];
                            biggestOfAKind[1] = i + 1;
                        }
                    }
                    Console.WriteLine("\nBiggest of a kind {0} {1}s \n", biggestOfAKind[0], biggestOfAKind[1]);
                    if (biggestOfAKind[0] != 2)
                    {
                        rolled = 1;
                        if (biggestOfAKind[0] > 2)
                        {
                            int pointToAdd = scores[(biggestOfAKind[0] - 3)];
                            gamePoints[turn] += pointToAdd;
                        }

                    }
                    else
                    {
                        string[] arrayChoices = { "Yes", "No" };
                        rolled = testing.Checker("Hey you rolled 2 of-a-kind would you like to ReRoll?:", arrayChoices);
                    }
                }

                if (gamePoints[turn] > 19) {
                    int otherPlayerTurn = 0;
                    if (turn == 0) { otherPlayerTurn = 1; }
                    Console.WriteLine("Player {0} Won! they rolled a total of {1} in {2} turns", turn + 1, gamePoints[turn], turns[turn]);
                    Console.WriteLine("Player {0} rolled {1} in {2} turns \n", otherPlayerTurn + 1, gamePoints[otherPlayerTurn], turns[otherPlayerTurn]);
                    points[turn]++;
                    i2 = 4;
                }
            }
            return points;
        }  

        //2 x dice
        //Rules:
        //Roll the two dice, noting the total rolled each time.
        //	If it is a 7 - stop.
        //	If it is any other number - add it to your total.
        //		If it is a double - add double the total to your score (3,3 would add 12 to your total)

        public int[] SevensOut(int[] points) 
        {
            int turn = 0;
            int[] playersTotal = { 0, 0 };
            for (int i = 0; i<2; i++) 
            {
                Console.WriteLine("");
                Console.WriteLine("Player {0}'s Turn :",(turn+1));
                int check = 0;
                while (check == 0)
                {
                    Console.WriteLine("ROLL: ");
                    Console.ReadLine();
                    int[] arrayOfDieRolls = Roll2Die();
                    int totalRoll = arrayOfDieRolls[0] + arrayOfDieRolls[1];
                    Console.WriteLine("1st Roll: {0}", arrayOfDieRolls[0]);
                    Console.WriteLine("2nd Roll: {0}", arrayOfDieRolls[1]);
                    Console.WriteLine("Total: {0}", totalRoll);
                    if (totalRoll == 7 )
                    {
                        check = 1;
                    }
                    else
                    {
                        playersTotal[turn] += totalRoll;
                    }
                }
                Console.WriteLine("Your Total:{0}",playersTotal[turn]);
                turn++;
            }
            Console.ReadLine();
            if (playersTotal[0] != playersTotal[1])
            {
                int winner = 0;
                if (playersTotal[0] < playersTotal[1])
                {
                    winner = 1;
                }
                points[winner]++;
                Console.WriteLine("Player {0} Won! ({1}:{2})", (winner + 1), playersTotal[0], playersTotal[1]);
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
        /// <returns>array for count of each possible roll</returns>
        private int[] checkForMultiples(int[] arrayOfDieRolls) 
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

            // used during testing / debug

            //Console.Write("\n");
            //foreach(int i in rollOptions)
            // {
            //   Console.Write(i);
            // }
            //Console.Write("\n");

           return rollOptions;
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

    }
}
