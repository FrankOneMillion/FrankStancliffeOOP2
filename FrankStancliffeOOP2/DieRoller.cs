﻿using System;
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
        /// <returns>int between 1 and 6</returns>
        public int Roll()
        {
            _rollValue = random.Next(1,7);
            return _rollValue;
        }
        
    }
}
