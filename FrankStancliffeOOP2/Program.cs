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
            Testing testingObject = new Testing();
            testingObject.TestProgram();

            Statistics statistics = new Statistics();
            Statistics.numberofplays playsCounter = new Statistics.numberofplays(statistics);
            GameModes newGame = new GameModes(statistics);
            Testing testing = new Testing();
            statistics.readTextFile();
            


            string[] arrayChoices ={ "Partner", "Computer" };
            int partnerChoice = testing.Checker("Play with partner(on the same computer), or against the computer.", arrayChoices);
            int[] points = { 0, 0, 0 };
            int gameChoice = 0;
            while (gameChoice != 2)
            {
                Console.WriteLine("Current Points: {0},{1}", points[0], points[1]);
                arrayChoices = new string[] { "Three Or More", "Sevens Out", "Quit from program" };
                gameChoice = testing.Checker("Would you like to play ", arrayChoices);
                if (gameChoice == 0) { points = newGame.ThreeOrMore(points, partnerChoice); playsCounter.increasePlayCounter(3); playsCounter.highScoreCheck(points[2], 3); }
                if (gameChoice == 1) { points = newGame.SevensOut(points, partnerChoice); playsCounter.increasePlayCounter(7); playsCounter.highScoreCheck(points[2], 7); }
            }
            for (int i = 0; i<2; i++) { for (int i2 = points[i];i2!=0;i2--) { playsCounter.playerWinCounter(i);Console.WriteLine("HEY it went up"); } }
            statistics.writeTextFile();
            //Console.ReadLine();
        }
    }
}
