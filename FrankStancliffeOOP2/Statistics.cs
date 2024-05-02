using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace FrankStancliffeOOP2
{
    public class Statistics
    {
        private int[] dataFromTextFile;
        public int highScoreSevensOut = 0;
        public int highScoreThreeOrMore = 0;
        public int sevensOutPlays = 0;
        public int threeOrMorePlays = 0;
        public int playerOneWins = 0;
        public int playerTwoWins = 0;
        /// <summary>
        /// finds current location of program within file system of user to allow file paths to be found for seperate files needed to operate the program such as the StoredValues.txt
        /// </summary>
        /// <param name="fileName">a text string holding the basic name of the file such as document.txt but not the path of the file</param>
        /// <returns>complete file path for chosen file</returns>
        public string findFilePath(string fileName)
        {
            string filePath = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName, fileName);
            // use of .GetCurrent and .GetParent allow this code to run well on many systems
            // compared to just stating a single location which could may not exist on other systems
            // due to program potentially being stored in an alternate location
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
            string[] linesOfFile = File.ReadAllLines(findFilePath(fileName));//creating string array of the text file
            int fileLength = linesOfFile.Length;

            for (int i = 0; i < fileLength; i++)
            { // runs for each line in the file, checking if it holds an int value whih would then be added to a new array
                if (int.TryParse(linesOfFile[i], out int newItem)) // to check if int or string
                {
                    Array.Resize(ref newArray, newArray.Length + 1);
                    newArray[newArray.Length - 1] = newItem;
                }
            }
            return newArray;
        }

        /// <summary>
        /// this method reads the chosen text file and sets variables to their corresponding values found within the text file
        /// </summary>
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
        /// <summary>
        /// this method writes the variables newer values / data back within the text file
        /// </summary>
        public void writeTextFile()
        {
            // updating array to hold newest values
            dataFromTextFile[0] = highScoreSevensOut;
            dataFromTextFile[1] = sevensOutPlays;
            dataFromTextFile[2] = highScoreThreeOrMore;
            dataFromTextFile[3] = threeOrMorePlays;
            dataFromTextFile[4] = playerOneWins;
            dataFromTextFile[5] = playerTwoWins;
            string[] intsAsStrings = Array.ConvertAll(dataFromTextFile, x => x.ToString());
            // includes text that can be read by user to show which statistics each int refers to
            string[] textForArray = { "// Highest Sevens Out Score", intsAsStrings[0],"// Sevens Out Plays", intsAsStrings[1],"// Highest Three Or More Score", intsAsStrings[2], "// Three Or More Plays", intsAsStrings[3], "// Player One Wins (Individual Games)", intsAsStrings[4],"// Player Two / Computer Wins (Individual Games)", intsAsStrings[5] };
            File.WriteAllLines((findFilePath("StoredValues.txt")), textForArray);
        }
        /// <summary>
        /// holds methods such as increasePlayCounter() highScoreCheck() and playerWinCounter() which manipulate the statistics data stored in the text file
        /// </summary>
        public class numberofplays:Statistics
        {
            private Statistics statistics;
            public numberofplays(Statistics statistics) {  this.statistics = statistics; }
            /// <summary>
            ///  increments play counters for three or more and sevens out dependant on input
            /// </summary>
            /// <param name="sevensOrThree"> used to identify whether to increment play counter for 3 or more game or sevens out</param>
            public void increasePlayCounter(int sevensOrThree)
            {
                if (sevensOrThree == 7) { statistics.sevensOutPlays++;  }
                else { statistics.threeOrMorePlays++; }
            }
            /// <summary>
            /// compares current score with high score for the current game mode, if current score is higher the high score is changed to match this value
            /// </summary>
            /// <param name="score"> the score of the current game / turn</param>
            /// <param name="sevensOrThree">represent which game mode is being played</param>
            public void highScoreCheck(int score, int sevensOrThree)
            {
                if (sevensOrThree == 7) { if (score > statistics.highScoreSevensOut) { statistics.highScoreSevensOut = score; } }
                else { if (score > statistics.highScoreThreeOrMore) { statistics.highScoreThreeOrMore = score; } }
            }
            /// <summary>
            /// increments value for each players win counter dependant on input refering to which player has won
            /// </summary>
            /// <param name="turn">used to identify which player to give a point / increment which win counter</param>
            public void playerWinCounter(int turn) { if (turn == 0) { statistics.playerOneWins++; } else { statistics.playerTwoWins++; } }
        }

    }
}

