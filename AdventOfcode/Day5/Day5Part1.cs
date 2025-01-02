using System;
namespace Day5
{
    public class Day5Part1
    {
        string line;
        List<string> codePuzzle = new List<string>();
        List<(int, int)> pageOrderingRules = new List<(int, int)>();
        List<string> safetyManual = new List<string>();

        // string csvFile = "Day5/test4.csv";
        string csvFile = "testData.csv";

        public void RunDay5()
        {
            ReadDataFromFile();
            SeparateRulesFromManual(codePuzzle);
        }

        private void ReadDataFromFile()
        {
            //file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(csvFile);
            //Read the first line of text
            line = sr.ReadLine();
            //Continue to read until you reach end of file
            while (line != null)
            {
                //write the line to console window
                Console.WriteLine(line);
                codePuzzle.Add(line);
                //Read the next line
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();
        }

        private void SeparateRulesFromManual(List<string> puzzles)
        {
            int emptyPuzzle = 0;
            

            for(int i = 0; i < puzzles.Count(); i++)
            {
                if(!string.IsNullOrEmpty(puzzles[i]))
                {
                    // string[] slpitedPuzzle = puzzles[i].Split('|');
                    int[] slpitedPuzzle = puzzles[i].Split('|').Select(x => int.Parse(x)).ToArray();

                    // pageOrderingRules.Add((int.Parse(slpitedPuzzle[0]), int.Parse(slpitedPuzzle[1])));
                    pageOrderingRules.Add((slpitedPuzzle[0], slpitedPuzzle[1]));

                    // text.Split('|').Select(x => int.Parse(x));
                }
                else
                {
                    emptyPuzzle = i;
                    Console.WriteLine($"{emptyPuzzle}");
                    break;
                }
            }
        }

    }
}
