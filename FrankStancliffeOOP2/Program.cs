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
            Testing testing = new Testing();
            //string[] arrayChoices = { "Yes", "No" };
            //int quit = testing.Checker("would you like to continue?", arrayChoices);

            //string[] arrayChoices = { "Three or More", "Sevens Out" };
            string[] arrayChoices = { "Partner", "Computer" };
            int quit = testing.Checker("Play with partner(on the same computer), or against the computer.", arrayChoices);
            //int quit = testing.Checker("would you like to continue?", arrayChoices);
            //while (quit != 1)
            //{

            // }
            GameModes newGame = new GameModes();
            int[] points = { 0, 0 };
            points = newGame.ThreeOrMore(points);
            points = newGame.SevensOut(points);
            Console.ReadLine();


        }
    }
}
