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
        /// <summary>
        /// runs basic tests that cover different methods within classes used throught my program
        /// </summary>
        public void TestProgram() {
            TestingDie();
            TestingIncreasingPlayCounter();
            TestingCheckerMethod();
            TestingMultipleChecker();
            Console.WriteLine("");
        }
        /// <summary>
        /// tests the Checker() method from the testing class, and that its returned intager is within the expected range
        /// </summary>
        private void TestingCheckerMethod() 
        {
            Testing testing = new Testing();
            string[] arrayChoices = { "Option 0", "Option 1","Option 2" };
            Debug.Assert((testing.Checker("Test Options ", arrayChoices) < (arrayChoices.Length)), "Choice value from Checker was above expected range (positions in array)");
            Console.WriteLine("Testing Checker Method Complete");
        }
        /// <summary>
        /// tests the checkForMultiples() method from the GameModes class
        /// </summary>
        private void TestingMultipleChecker() 
        {
            Statistics statistics = new Statistics();
            GameModes newGame = new GameModes(statistics);
            int[] arrayOfDieRolls = { 1, 2, 3, 6, 6, 6 };
            int[] expectedArray = {3,6};
            //foreach(int i in newGame.checkForMultiples(arrayOfDieRolls)) { Console.WriteLine(i); }
            Debug.Assert((newGame.checkForMultiples(arrayOfDieRolls) != expectedArray),"Check for multiples method not working as expected");
            Console.WriteLine("Testing check for multiples method complete");
            
        }
        /// <summary>
        /// tests that after using increasePlayCounter method, that the value for threeOrMorePlays increments
        /// </summary>
        private void TestingIncreasingPlayCounter()
        {
            Statistics statistics = new Statistics();
            Statistics.numberofplays playsCounter = new Statistics.numberofplays(statistics);
            int oldInt = playsCounter.threeOrMorePlays;
            playsCounter.increasePlayCounter(3);
            Debug.Assert((playsCounter.threeOrMorePlays == oldInt),"increasePlayCounter did not increase the play counter");
            Console.WriteLine("Testing for increasing play counter complete");
        }
        /// <summary>
        /// tests both the Roll5Die and Roll2Die Methods from the GameMode class
        /// </summary>
        private void TestingDie() { 
            Statistics statistics = new Statistics(); 
            GameModes newGame = new GameModes(statistics); 
            int[] fiveDieArray = newGame.Roll5Die(); 
            int[] twoDieArray = newGame.Roll2Die();
            int counter = 0;
            foreach (int die in fiveDieArray) { counter++; Debug.Assert((7 > die && die > 0), "a die rolled outside of expected range (1-6) from Roll5Die()"); }
            Debug.Assert((counter == (5)), "Five Die were not rolled from Roll5Die()");
            counter = 0;
            foreach (int die in twoDieArray) { counter++; Debug.Assert((7 > die && die > 0), "a die rolled outside of expected range (1-6) from Roll2Die()"); }
            Debug.Assert((counter == (2)), "Two Die were not rolled from Roll2Die()");
            Console.WriteLine("Testing die methods from GameModes class complete");
        }
    }
}
