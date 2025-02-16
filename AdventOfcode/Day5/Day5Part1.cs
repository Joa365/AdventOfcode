using System;
namespace AdventOfcode.Day5
{
    public class Day5Part1
    {
        string? line;
        List<string> codePuzzle = new List<string>();
        string csvFile = "Day5/input5.csv";
        // string csvFile = "testData.csv";

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
                // Console.WriteLine(line);
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
            int puzzlesNumber = puzzles.Count();

            List<(string, string)> pageOrderingRules = new List<(string, string)>();
            List<string> safetyManual = new List<string>();
            
            for(int i = 0; i < puzzlesNumber; i++)
            {
                if(!string.IsNullOrEmpty(puzzles[i]))
                {
                    string[] slpitedPuzzle = puzzles[i].Split('|');
                    // int[] slpitedPuzzle = puzzles[i].Split('|').Select(x => int.Parse(x)).ToArray();

                    // pageOrderingRules.Add((int.Parse(slpitedPuzzle[0]), int.Parse(slpitedPuzzle[1])));
                    pageOrderingRules.Add((slpitedPuzzle[0], slpitedPuzzle[1]));

                    // text.Split('|').Select(x => int.Parse(x));
                }
                else
                {
                    emptyPuzzle = i;
                    // Console.WriteLine($"{emptyPuzzle}");
                    break;
                }
            }

            for( int i = emptyPuzzle + 1; i < puzzlesNumber; i ++)
            {
                // Console.WriteLine($"{puzzles[i]}");
                safetyManual.Add(puzzles[i]);
            }

            SelectPagesInCorrectOrder(pageOrderingRules, safetyManual);
        }

        private void SelectPagesInCorrectOrder(List<(string pageOne, string pageTwo)> manuals, List<string> pagesToPrint)
        {
            List<string> correctInOrderPages = new List<string>();
            int maualLenght = manuals.Count();

            foreach(string page in pagesToPrint)
            {
                int i = 0;

                foreach(var manual in manuals)
                {
                    int indexPageOne = page.IndexOf(manual.pageOne);
                    int indexPageTwo = page.IndexOf(manual.pageTwo);

                    if(indexPageTwo != -1 && indexPageTwo !=-1)
                    {
                        if(indexPageOne > indexPageTwo)
                        {
                            break;
                        }
                    }
                    i++;
                }

                if(i == maualLenght)
                {
                    correctInOrderPages.Add(page);
                    // Console.WriteLine($"{page}");
                }
            }

            // Console.WriteLine($"{correctInOrderPages.Count()}");
            MiddelValue(correctInOrderPages);
        }

        private void MiddelValue(List<string> correctPages)
        {
            int sum = 0;
            foreach(var page in correctPages)
            {
                int[] splitedPages = page.Split(',').Select(x => int.Parse(x)).ToArray(); 
                int splitedPagesLenght = splitedPages.Count();
                int middleIndex = (splitedPagesLenght - 1) / 2;
                sum += splitedPages[middleIndex];
            }

            Console.WriteLine($"Wynik obliczen: {sum}");
        }
    }
}
