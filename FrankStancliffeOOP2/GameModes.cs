using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrankStancliffeOOP2
{
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
        public void ThreeOrMore() { }

        //2 x dice
        //Rules:
        //Roll the two dice, noting the total rolled each time.
        //	If it is a 7 - stop.
        //	If it is any other number - add it to your total.
        //		If it is a double - add double the total to your score (3,3 would add 12 to your total)
        public void SevensOut() { }
    }
}
