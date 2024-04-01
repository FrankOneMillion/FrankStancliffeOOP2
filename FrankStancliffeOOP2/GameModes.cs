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
            int turn = 0;
            int rolled = 0;
            while (rolled != 1)
            {
                int[] arrayOfDieRolls = Roll5Die();
                int[] rollOptions = checkForMultiples(arrayOfDieRolls);
                int biggestOfAKind = 0;
                for (int i = 0; i < rollOptions.Length; i++)
                {
                    if (rollOptions[i] > biggestOfAKind) { biggestOfAKind = rollOptions[i]; }
                }
                if (biggestOfAKind != 2) { rolled = 1; }
                else
                {
                    // Console.WriteLine("Hey you rolled 2 of-a-kind would you like to ReRoll?:")
                    // rolled = checker(["Yes","No"])
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
            return points;
        }

        /// <summary>
        /// used in ThreeOrMore class to calculate number of matching / of-a-kind
        /// </summary>
        /// <param name="arrayOfDieRolls">array containing the rolls from the 5 die</param>
        /// <returns>array for count of each possible roll</returns>
        private int[] checkForMultiples(int[] arrayOfDieRolls) 
        {
            int[] rollOptions = { 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < arrayOfDieRolls.Length; i++)
            {
                for (int j = 0; i < rollOptions.Length; j++)
                {
                    if (rollOptions[j] == arrayOfDieRolls[i])
                    {
                        rollOptions[j]++;
                    }
                }
            }
            return rollOptions;
        }
        /// <summary>
        /// creates 2 new die objects and rolls them
        /// </summary>
        /// <returns>array containing the two rolled values</returns>
        public int[] Roll5Die()
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
        public int[] Roll2Die()
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
