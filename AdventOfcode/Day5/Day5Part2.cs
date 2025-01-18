using System;
using System.Runtime.CompilerServices;

namespace AdventOfcode.Day5;

public class Day5Part2
{
        string line;
        int callingNumber = 0;
        int sum = 0;

        List<string> codePuzzle = new List<string>();
         List<string> correctInOrderPages = new List<string>();

        string csvFile = "Day5/input5.csv";
        // string csvFile = "testData.csv";

        public void RunDay5Part2()
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
                    pageOrderingRules.Add((slpitedPuzzle[0], slpitedPuzzle[1]));
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
            MiddelValue(correctInOrderPages);
        }

        private void SelectPagesInCorrectOrder(List<(string pageOne, string pageTwo)> manuals, List<string> pagesToPrint)
        {   
            callingNumber ++;
            List<string> incorrectOrderPages = new List<string>();

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
                            incorrectOrderPages.Add(page);
                            break;
                        }
                    }
                    i++;
                }

                if(i == maualLenght && callingNumber > 1)
                {
                    correctInOrderPages.Add(page);
                }
            }

            if(incorrectOrderPages.Count() > 0)
            {
                SortPages(manuals, incorrectOrderPages);
            }

          
        }

        private void SortPages(List<(string pageOne, string pageTwo)> manuals, List<string> pagesToSort)
        {
            // List<string> pages = pagesToSort.ToList();
             List<PagesToPrint> pageSelectedToSwap = new List<PagesToPrint>();
            int i = 0;
            foreach(var page in pagesToSort)
            {
                string[] splitPages = page.Split(',');
                var pagesToPrintItem = new PagesToPrint
                {
                    Id = i,
                    PagesToSort = splitPages
                };
                pageSelectedToSwap.Add(pagesToPrintItem); 
                i ++;
            }
            // List<PagesToPrint> pagesToSwap = pageSelectedToSwap.ToList();
            foreach(var page in pageSelectedToSwap)
            {
                foreach(var manual in manuals)
                {
                    int indexPageOne = Array.IndexOf(page.PagesToSort, manual.pageOne);
                    int indexPageTwo = Array.IndexOf(page.PagesToSort, manual.pageTwo);

                    if(indexPageTwo != -1 && indexPageTwo !=-1)
                    {
                        if(indexPageOne > indexPageTwo)
                        {
                            SwapPages(page.Id, indexPageOne, indexPageTwo, pageSelectedToSwap);
                            break;
                        }
                    }
                }
            }
            //Adding pageSelectedToSwap to the list pages to verify
            var pagesToVerify = pageSelectedToSwap.Select(x => string.Join(',', x.PagesToSort)).ToList();
            SelectPagesInCorrectOrder(manuals, pagesToVerify);
        }

        private void SwapPages(int id, int index1, int index2, List<PagesToPrint> pagesSwap )
        {
            var result = pagesSwap.Where(x => x.Id == id).Select( p => p.PagesToSort).First();

            string temp = result[index1];
            result[index1] = result[index2];
            result[index2] = temp;

            pagesSwap.Where(x => x.Id == id).Select(p => p.PagesToSort = result.ToArray()).ToList();

        }

        private void MiddelValue(List<string> correctPages)
        {
            foreach(var page in correctPages)
            {
                int[] splitedPages = page.Split(',').Select(x => int.Parse(x)).ToArray(); 
                int splitedPagesLenght = splitedPages.Count();
                int middleIndex = (splitedPagesLenght - 1) / 2;
                sum += splitedPages[middleIndex];
            }

            Console.WriteLine($"middle page numbers: {sum}");
        }

       
}

public class PagesToPrint
{
    public int Id {get; set;}
    public string[] PagesToSort{get; set;}
}
