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
            arrayChoices = { "Three Or More", "Sevens Out", "Quit" };
            int gameChoice = testing.Checker("Would you like to play ", arrayChoices);
            //int quit = testing.Checker("would you like to continue?", arrayChoices);
            //while (quit != 1)
            //{

            // }
            GameModes newGame = new GameModes();
            int[] points = { 0, 0 };
            //while (Console.ReadLine() != "q") {
            //for (int i = 0; i<3; i++)
            //{
            points = newGame.ThreeOrMore(points);
            foreach (int point in points) { Console.WriteLine(point); }
            //points = newGame.ThreeOrMore(points);
            //points = newGame.SevensOut(points);
            Console.ReadLine();


        }
    }
}
