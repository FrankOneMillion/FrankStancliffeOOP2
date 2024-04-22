using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FrankStancliffeOOP2.Statistics;

namespace FrankStancliffeOOP2
{
    ///
    public class Statistics
    {
        public int counter = 0;
        public int highScore = 0;
        public class numberofplays:Statistics
        {

            public void playscounter()
            {
                counter++;
            }
        }

    }
}

