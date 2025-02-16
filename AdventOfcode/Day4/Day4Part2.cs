using System;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Security;
using System.Reflection.Metadata;
using System.Runtime.ExceptionServices;
using CsvHelper.Configuration;


namespace Day4
{
    public class Day4Part2
    {
        List<string> codePuzzle = new List<string>(); 
        string? line;
         char[] xMasInput = ['M', 'A', 'S'];
         char[] xMasReverse = ['S', 'A', 'M'];
        const int xMasLenght = 3;
       
        // string csvFile = "Day4/data4.csv";
        // string csvFile = "Day4/test4.csv";
        string csvFile = "testData.csv";
        // string csvFile = "input9.csv";
        public void CalculateXmax()
        {
            int xMasScore = 0;
            ReadDataFromFile();
            //Count may x-mas starst from M
            xMasScore += DiagonalXmasPositions(codePuzzle, 'M', xMasInput);
            //Count how amy x-Mas starst from S
            xMasScore += DiagonalXmasPositions(codePuzzle, 'S', xMasReverse);
         

            Console.WriteLine($"X-Mas Score: {xMasScore}");
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
                // Console.WriteLine(line);
                codePuzzle.Add(line);
                //Read the next line
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();

        }

        private int DiagonalXmasPositions(List<string> puzzles, char xMasStartLetter, char[] xMas)
        {
            int diagonalXmasScore =0;
            int index = -1;            
            bool firstXmas = false;
            bool secondXmas = false; 

            int puzzelNumber = puzzles.Count(); 
        
            for(int i =0; i < puzzelNumber -2; i++)
            {
                int puzzleLenght = puzzles[i].Length;
                int n=0;
                do
                {
                    int diagonalPartalScore = 0;
                    index = puzzles[i].IndexOf(xMasStartLetter, n);
                    if(index != -1 )
                    {
                        for(int j = 1; j < xMasLenght; j++)
                        {
                            //Spradź kolejna literę
                            if(index + j < puzzleLenght)
                            {
                                bool mas = TheSameCharacter(puzzles[i + j], index + j, xMas[j]);
                                if(mas)
                                {
                                    diagonalPartalScore ++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        if(diagonalPartalScore == 2)
                        {   
                            firstXmas = true;
                            if(index + 2 < puzzleLenght)
                            {
                                char letter = puzzles[i][index+2];
                            
                                // First letter is M
                                if(letter== 'M')
                                {
                                    secondXmas = SecondXMas(puzzles, i, index, xMasInput);
                                }
                                //First letter is'S'
                                else if(letter == 'S')
                                {
                                    // secondXmas = SecondXmasStarstsFromS(puzzels, i, index);
                                    secondXmas =  SecondXMas(puzzles, i, index, xMasReverse);
                                }
                                else 
                                {
                                    secondXmas = false;
                                }
                            }
                        }
                    }               
                    if(firstXmas && secondXmas)
                    {
                        diagonalXmasScore ++;
                    }
                    n = index + 1;
                    firstXmas = false;
                    secondXmas = false; 
                }
                while(index != -1 && index < puzzleLenght);
            }                  
            return diagonalXmasScore;
        }

        private bool SecondXMas(List<string> puzzels, int i, int indexM, char[] xMas)
        {
            bool masM = false;
            int partialMasScore = 0;

                //Sprawdź czy bedzie x-MAS
                for(int j = 1; j < xMasLenght; j++)
                {
                    bool sameLetter = TheSameCharacter(puzzels[i + j], indexM + 2 - j,  xMas[j]);
                    //Spradź kolejna literę od M do S
                    if(sameLetter)
                    {
                        partialMasScore ++;
                    }
                    else
                    {
                        break;
                    }
                }
                if(partialMasScore == 2)
                {
                    masM = true;
                }
            
            return  masM;
        }

        /// <summary>
        /// /Metdoa zwracająca czy przezkazywamnym string puzzel, o indexie index, jest przekazywanym argumnet letter
        /// </summary>
        /// <param name="puzzel"></param>
        /// <param name="index"></param>
        /// <param name="letter"></param>
        /// <returns></returns>
        private bool TheSameCharacter(string puzzle, int index, char letter)
        {
            bool theSameLetter = false;
               
            char letterResult = puzzle[index];
            if(letter == letterResult)
            {
                theSameLetter = true;
            }
            return theSameLetter;
        }
    }
}
