using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace FrankStancliffeOOP2
{
    ///
    public class Statistics
    {
        private int[] dataFromTextFile;
        public int highScoreSevensOut = 0;
        public int highScoreThreeOrMore = 0;
        public int sevensOutPlays = 0;
        public int threeOrMorePlays = 0;
        public int playerOneWins = 0;
        public int playerTwoWins = 0;
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
            string[] stringsWithinArray = { };
            string[] linesOfFile = File.ReadAllLines(findFilePath(fileName));
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
            dataFromTextFile = CreatingAnArray("StoredValues.txt");
            highScoreSevensOut = dataFromTextFile[0];
            sevensOutPlays = dataFromTextFile[1];
            highScoreThreeOrMore = dataFromTextFile[2];
            threeOrMorePlays = dataFromTextFile[3];
            playerOneWins = dataFromTextFile[4];
            playerTwoWins = dataFromTextFile[5];
            //Console.WriteLine("{0}{1}",counter,highScore); //used during inital testing
        }

        public void writeTextFile()
        {
            dataFromTextFile[0] = highScoreSevensOut;
            dataFromTextFile[1] = sevensOutPlays;
            dataFromTextFile[2] = highScoreThreeOrMore;
            dataFromTextFile[3] = threeOrMorePlays;
            dataFromTextFile[4] = playerOneWins;
            dataFromTextFile[5] = playerTwoWins;
            //Console.WriteLine("HEY!! {0}",sevensOutPlays);
            string[] intsAsStrings = Array.ConvertAll(dataFromTextFile, x => x.ToString());
            //foreach (string str in intsAsStrings) { Console.WriteLine(str); };
            //Console.ReadLine();
            string[] textForArray = { "// Highest Sevens Out Score", intsAsStrings[0],"// Sevens Out Plays", intsAsStrings[1],"// Highest Three Or More Score", intsAsStrings[2], "// Three Or More Plays", intsAsStrings[3], "// Player One Wins (Individual Games)", intsAsStrings[4],"// Player Two / Computer Wins (Individual Games)", intsAsStrings[5] };
            //int counter = 0;
            //foreach(string line in intsAsStrings) { Console.WriteLine(textForArray[counter]); Console.WriteLine(line);counter++; }
            File.WriteAllLines((findFilePath("StoredValues.txt")), textForArray);
        }

        public class numberofplays:Statistics
        {
            private Statistics statistics;
            public numberofplays(Statistics statistics) {  this.statistics = statistics; }
            public void increasePlayCounter(int sevensOrThree)
            {
                if (sevensOrThree == 7) { statistics.sevensOutPlays++;  }
                else { statistics.threeOrMorePlays++; }
            }
            public void highScoreCheck(int score, int sevensOrThree)
            {
                if (sevensOrThree == 7) { if (score > statistics.highScoreSevensOut) { statistics.highScoreSevensOut = score; } }
                else { if (score > statistics.highScoreThreeOrMore) { statistics.highScoreThreeOrMore = score; } }
            }
            public void playerWinCounter(int turn) { if (turn == 0) { statistics.playerOneWins++; } else { statistics.playerTwoWins++; } }
        }

    }
}

