using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrankStancliffeOOP2
{
    internal class Testing
    {
        /// <summary>
        /// used throught program to validate user input and allow users to choose option from entered array
        /// </summary>
        /// <param name="arrayOfStringOptions"> array of possible options for user to choose from</param>
        /// <returns> an int value representing position of choice within original inputted array</returns>
        public int Checker(string question, string[] arrayOfStringOptions)
        {
            int returnPoison = 0;
            List<string> possibleInputs = new List<string> { };
            for (int i = 0; i < arrayOfStringOptions.Length; i++)
            {
                possibleInputs.Add(i.ToString());
                //Console.WriteLine("{1}: {0}",arrayOfStringOptions[i],possibleInputs[i]);
            }
            int checkVar = 0;
            while (checkVar != 1)
            {
                Console.WriteLine(question);
                for (int i = 0; i < arrayOfStringOptions.Length; i++)
                {
                    Console.WriteLine("{1}: {0}", arrayOfStringOptions[i], possibleInputs[i]);
                }
                string userInput = Console.ReadLine();
                for (int i = 0; i < possibleInputs.Count; i++) {
                    if (userInput == possibleInputs[i]) {
                        checkVar = 1; returnPoison = i; break;
                    }
                }
                if (checkVar != 1) { Console.WriteLine("Hey, i didnt expect that answer :( please try again \n "); }
            }

            return returnPoison;
        }
        public void TestProgram() {

            Statistics statistics = new Statistics();
            Statistics.numberofplays playsCounter = new Statistics.numberofplays(statistics);
            GameModes newGame = new GameModes(statistics);
            statistics.readTextFile();
            TestingDie();
            Console.WriteLine("Testing die methods from GameModes class complete");
            TestingIncreasingPlayCounter();
            Console.WriteLine("Testing for increasing play counter complete");

            string[] arrayChoices = { "Partner", "Computer" };
            TestingCheckerMethod();

            int[] points = { 0, 0, 0 };
            int gameChoice = 0;
            while (gameChoice != 2)
            {
                Console.WriteLine("Current Points: {0},{1}", points[0], points[1]);
                arrayChoices = new string[] { "Three Or More", "Sevens Out", "Quit from program" };
                gameChoice = testing.Checker("Would you like to play ", arrayChoices);
                TestingCheckerMethod(gameChoice, arrayChoices);
                if (gameChoice == 0) { points = newGame.ThreeOrMore(points, partnerChoice); playsCounter.increasePlayCounter(3); playsCounter.highScoreCheck(points[2], 3); }
                if (gameChoice == 1) { points = newGame.SevensOut(points, partnerChoice); playsCounter.increasePlayCounter(7); playsCounter.highScoreCheck(points[2], 7); }
            }
            for (int i = 0; i < 2; i++) { for (int i2 = points[i]; i2 != 0; i2--) { playsCounter.playerWinCounter(i); } }
        }
        private void TestingCheckerMethod() 
        {
            Testing testing = new Testing();
            string[] arrayChoices = { "Option 0", "Option 1","Option 2" };
            Debug.Assert((testing.Checker("Test Options ", arrayChoices) < (arrayChoices.Length)), "Choice value from Checker was above expected range (positions in array)"); 
        }
        private void TestingPoints(int[] points) { }
        private void TestingGame(int[] points) { }
        private void TestingIncreasingPlayCounter()
        {
            Statistics statistics = new Statistics();
            Statistics.numberofplays playsCounter = new Statistics.numberofplays(statistics);
            int oldInt = playsCounter.threeOrMorePlays;
            playsCounter.increasePlayCounter(7);
            Debug.Assert((playsCounter.threeOrMorePlays == oldInt),"increasePlayCounter did not increase the play counter");
        }

        private void TestingDie() { Statistics statistics = new Statistics(); GameModes newGame = new GameModes(statistics); int[] fiveDieArray = newGame.Roll5Die(); int[] twoDieArray = newGame.Roll2Die();
            int counter = 0;
            foreach (int die in fiveDieArray) { counter++; Debug.Assert((7 > die && die > 0), "a die rolled outside of expected range (1-6) from Roll5Die()"); }
            Debug.Assert((counter != (5)), "Five Die were not rolled from Roll5Die()");
            counter = 0;
            foreach (int die in twoDieArray) { counter++; Debug.Assert((7 > die && die > 0), "a die rolled outside of expected range (1-6) from Roll2Die()"); }
            Debug.Assert((counter != (2)), "Two Die were not rolled from Roll2Die()");
        }
    }
}
