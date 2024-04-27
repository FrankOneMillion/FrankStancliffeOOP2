using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace FrankStancliffeOOP2
{
    ///
    public class Statistics
    {
        public string findFilePath(string fileName)
        {
            string filePath = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName, fileName);
            return filePath;
        }
        /// <summary>
        /// RE_USED and adapted method from previous assigmnent 
        /// this method takes the file name and locates a file with that name before adding only intagers within the file into a array
        /// </summary>
        /// <param name="fileName"> input of the file name for the text file</param>
        /// <returns> returns an array based from inputted file </returns>
        public int[] CreatingAnArray(string fileName)
            {
                int[] newArray = { };
                string[] linesOfFile = File.ReadAllLines(findFilePath( fileName));
                // use of .GetCurrent and .GetParent allow this code to run well on many systems
                // compared to just stating a single location which could may not exist on other systems
                // due to program potentially being stored in an alternate location
                int fileLength = linesOfFile.Length;

                for (int i = 0; i < fileLength; i++)
                { // runs for each line in the file, adding each as a singluar int witin the new array
                if (int.TryParse(linesOfFile[i], out int newItem)) 
                {
                    Array.Resize(ref newArray, newArray.Length + 1);
                    newArray[newArray.Length - 1] = newItem;
                }
                }
            return newArray;
            }
        public void readTextFile()
        {
            dataFromTextFile = CreatingAnArray("TextFile1.txt");
            highScore = dataFromTextFile[0];
            counter = dataFromTextFile[1];
            Console.WriteLine("{0}{1}",counter,highScore);
        }

        public void writeTextFile()
        {
            dataFromTextFile[0] = highScore;
            dataFromTextFile[1] = counter;
            string[] linesToWrite = Array.ConvertAll(dataFromTextFile, x => x.ToString());
            foreach(string line in linesToWrite) { Console.WriteLine(line); }
            File.WriteAllLines((findFilePath("TextFile1.txt")), linesToWrite);
        }

        private int[] dataFromTextFile;
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

