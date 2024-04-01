using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrankStancliffeOOP2
{
    /// <summary>
    /// class holds ability to create a new die 
    /// </summary>
    internal class DieRoller
    {
        static Random random = new Random();
        private int _rollValue;

        /// <summary>
        /// rolls a int value between 1 and 6
        /// </summary>
        /// <returns>int between 1 andd 6</returns>
        private int Roll()
        {
            _rollValue = random.Next(1,7);
            return _rollValue;
        }
        public int[] Roll5Die()
        {
            DieRoller die1 = new DieRoller();
            DieRoller die2 = new DieRoller();
            int[] arrayOfDieRolls = { (die1.Roll()), (die2.Roll()) };
            return arrayOfDieRolls;
        }
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
