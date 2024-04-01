using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace FrankStancliffeOOP2
{
    internal class GameModes
    {
        Roller roller = new Roller();
        // 5 x dice
        //Rules:
        //Roll all 5 dice hoping for a 3-of-a-kind or better.
        //	If 2-of-a-kind is rolled, player may choose to rethrow all, or the remaining dice.
        //	3-of-a-kind: 3 points
        //	4-of-a-kind: 6 points
        //	5-of-a-kind: 12 points
        //    First to a total of 20.
        public int[] ThreeOrMore(int[] points) 
        {
            int turn = 0;
            int[] arrayOfDieRolls = roller.Roll5Die();
            int [] rollOptions = checkForMultiples(arrayOfDieRolls);
            int biggestOfAKind = 0;
            for (int i = 0; i < rollOptions.Length; i++) 
            {
                if (rollOptions[i] > biggestOfAKind) { biggestOfAKind = rollOptions[i]; }
            }
            if (biggestOfAKind != 2) { }
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
            for (int i = 0; i>1; i++) 
            {
                Console.WriteLine("Player {0}'s Turn :",turn+1);
                int check = 0;
                while (check == 0)
                {
                    int[] arrayOfDieRolls = roller.Roll2Die();
                    int totalRoll = arrayOfDieRolls[0] + arrayOfDieRolls[1];
                    Console.WriteLine("1st Roll: {0}", arrayOfDieRolls[0]);
                    Console.WriteLine("2nd Roll: {0}", arrayOfDieRolls[1]);
                    Console.WriteLine("Total: {0}", totalRoll);
                    Console.WriteLine("ROLL: ");
                    if (totalRoll == 7 || (Console.ReadLine()) == "q")
                    {
                        check = 1;
                    }
                    else
                    {
                        playersTotal[turn] += totalRoll;
                    }
                }
                Console.WriteLine("Your Total:{0}",playersTotal[turn]);
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
                Console.WriteLine("Draw ({0}:{1}) both players gain a point :)", playersTotal[0], playersTotal[1]);
            }
            return points;
        }
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
    }
}
