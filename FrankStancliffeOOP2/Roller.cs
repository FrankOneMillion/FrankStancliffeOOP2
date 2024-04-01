using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrankStancliffeOOP2
{
    internal class Roller
    {
        public int[] Roll5Die()
        {
            Die die1 = new Die();
            Die die2 = new Die();
            int[] arrayOfDieRolls = { (die1.Roll()), (die2.Roll()) };
            return arrayOfDieRolls;
        }
        public int[] Roll2Die() {
            Die die1 = new Die();
            Die die2 = new Die();
            Die die3 = new Die();
            Die die4 = new Die();
            Die die5 = new Die();
            int[] arrayOfDieRolls = { (die1.Roll()), (die2.Roll()), (die3.Roll()) , (die4.Roll()) , (die5.Roll()) };
            return arrayOfDieRolls;
        }
    }
}
