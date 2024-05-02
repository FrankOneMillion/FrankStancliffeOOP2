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
            testingObject.TestProgram(); // this method then calls a number of other methods from testing class allowing key methods/program to be tested

            Statistics statistics = new Statistics();
            Statistics.numberofplays playsCounter = new Statistics.numberofplays(statistics);
            GameModes newGame = new GameModes(statistics);
            Testing testing = new Testing();
            statistics.readTextFile(); // inital read of text file and setting of values within statistics class
            
            string[] arrayChoices ={ "Partner", "Computer" };
            int partnerChoice = testing.Checker("Play with partner(on the same computer), or against the computer.", arrayChoices);
            int[] points = { 0, 0, 0 };
            int gameChoice = 0;
            while (gameChoice != 2)
            {
                Console.WriteLine("Current Points: {0},{1}", points[0], points[1]);
                arrayChoices = new string[] { "Three Or More", "Sevens Out", "Quit from program" };
                gameChoice = testing.Checker("Would you like to play ", arrayChoices);
                // after game has ended, the play count for that game is incremented and score is saved to points in addition to curretn player turn to record high scores or wins for each player.
                if (gameChoice == 0) { points = newGame.ThreeOrMore(points, partnerChoice); playsCounter.increasePlayCounter(3); playsCounter.highScoreCheck(points[2], 3); }
                if (gameChoice == 1) { points = newGame.SevensOut(points, partnerChoice); playsCounter.increasePlayCounter(7); playsCounter.highScoreCheck(points[2], 7); }
            }
            for (int i = 0; i<2; i++) { for (int i2 = points[i];i2!=0;i2--) { playsCounter.playerWinCounter(i);Console.WriteLine("HEY it went up"); } }
            // writes new values back to the text file to esnure a high score is kept
            statistics.writeTextFile();
            //Console.ReadLine();
        }
    }
}
