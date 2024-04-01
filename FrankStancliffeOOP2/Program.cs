using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrankStancliffeOOP2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameModes newGame = new GameModes();
            int[] points = { 0, 0 };
            points = newGame.SevensOut(points);


        }
    }
}
