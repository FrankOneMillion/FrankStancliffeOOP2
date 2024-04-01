using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrankStancliffeOOP2
{
    /// <summary>
    /// main / primary program file
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            int play = 1;
            while (play == 1)
            {

            }
            GameModes newGame = new GameModes();
            int[] points = { 0, 0 };
            points = newGame.SevensOut(points);
            Console.ReadLine();


        }
    }
}
