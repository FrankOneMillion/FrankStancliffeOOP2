using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//2 x dice
//Rules:
//Roll the two dice, noting the total rolled each time.
//	If it is a 7 - stop.
//	If it is any other number - add it to your total.
//		If it is a double - add double the total to your score (3,3 would add 12 to your total)

namespace FrankStancliffeOOP2
{
    internal class SevensOut
    {
        Die die1= new Die();
        Die die2= new Die();
    }
}
