using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FrankStancliffeOOP2.Statistics;

namespace FrankStancliffeOOP2
{
    ///
    public class Statistics
    {
            /// <summary>
            /// RE_USED method from previous assigmnent 
            /// this method takes the file name and locates a file with that name before converting this line by line into a array of integers
            /// </summary>
            /// <param name="fileName"> input of the file name for the text file</param>
            /// <returns> returns an array based from inputted file </returns>
            public int[] CreatingAnArray(string fileName)
            {
                int[] newArray = { };
                string[] linesOfFile = File.ReadAllLines(Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName, fileName));
                // use of .GetCurrent and .GetParent allow this code to run well on many systems
                // compared to just stating a single location which could may not exist on other systems
                // due to program potentially being stored in an alternate location
                int fileLength = linesOfFile.Length;

                for (int i = 0; i < fileLength; i++)
                { // runs for each line in the file, adding each as a singluar int witin the new array
                    int newItem = int.Parse(linesOfFile[i]);
                    Array.Resize(ref newArray, newArray.Length + 1);
                    newArray[newArray.Length - 1] = newItem;
                }

                return newArray;
            }

        int[] dataFromTextFile = CreatingAnArray("TextFile1.txt");
        public int counter = 0;
        public int highScore = 0;
        public class numberofplays:Statistics
        {

            public void increasePlayCounter()
            {
                counter++;
            }
            public void highScoreCheck(int score)
            {
                if (score > highScore) { highScore = score; }
            }
        }

    }
}

