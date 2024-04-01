using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrankStancliffeOOP2
{
    internal class Die
    {
        static Random random = new Random();
        private int _rollValue;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Roll()
        {
            _rollValue = random.Next(1,7);
            return _rollValue;
        }
    }
}
