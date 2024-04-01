using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace FrankStancliffeOOP2
{
    internal class Testing
    {
        /// <summary>
        /// used throught program to validate user input and allow users to choose option from entered array
        /// </summary>
        /// <param name="arrayOfStringOptions"> array of possible options for user to choose from</param>
        /// <returns> an int value representing position of choice within original inputted array</returns>
        public int Checker(string question,string[] arrayOfStringOptions)
        {
            int returnPoison = 0;
            List<string> possibleInputs = new List<string> {  };
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
                string userInput=Console.ReadLine();
                for (int i = 0;i < possibleInputs.Count;i++) {
                    if (userInput == possibleInputs[i]) {
                        checkVar = 1; returnPoison = i; break;
                    }
                }
                if (checkVar != 1) { Console.WriteLine("Hey, i didnt expect that answer :( please try again \n "); }
            }

            return returnPoison;
        }
    }
}
