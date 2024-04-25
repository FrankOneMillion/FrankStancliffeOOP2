using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
            GameModes newGame = new GameModes();

            string[] arrayChoices ={ "Partner", "Computer" };
            int partnerChoice = testing.Checker("Play with partner(on the same computer), or against the computer.", arrayChoices);
            int[] points = { 0, 0 };
            int gameChoice = 0;
            while (gameChoice != 2)
            {
                Console.WriteLine("Current Points: {0},{1}", points[0], points[1]);
                arrayChoices = new string[] { "Three Or More", "Sevens Out", "Quit from program" };
                gameChoice = testing.Checker("Would you like to play ", arrayChoices);
                if (gameChoice == 0) { points = newGame.ThreeOrMore(points, partnerChoice); }
                if (gameChoice == 1) { points = newGame.SevensOut(points, partnerChoice); }
            }
        }
    }
}
