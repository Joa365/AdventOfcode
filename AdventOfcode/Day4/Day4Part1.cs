using System;
using System.Linq;


namespace Day4
{
    public class Day4Part1
    {
        List<string> codePuzzel = new List<string>(); 
        string line;
        const int xMasLenght = 4;
        char[] xMas = ['X', 'M', 'A', 'S'];

        string csvFile = "Day4/data4.csv";
        // string csvFile = "Day4/test4.csv";
        // string csvFile = "testData.csv";
        // string csvFile = "input9.csv";
        public void CalculateXmax()
        {
            int xMasScore = 0;
            ReadDataFromFile();

            foreach(var puzzel in codePuzzel)
            {
                xMasScore += HorizontalXmasPositon(puzzel);
            }
                xMasScore += VerticalXmasPositons(codePuzzel);
                xMasScore += DiagonalXmasPositions(codePuzzel);
                
                //Reverse VerticalXmasPosition                
                codePuzzel.Reverse();
                xMasScore += VerticalXmasPositons(codePuzzel);
                xMasScore += DiagonalXmasPositions(codePuzzel);

            Console.WriteLine(xMasScore);
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
                codePuzzel.Add(line);
                //Read the next line
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();

        }

        private int HorizontalXmasPositon(string puzzelLine)
        {
            int horizontalXmasScore = 0;

            for(int i= 0;  i < puzzelLine.Length; i++)
            {
                int comparisonResult = 0;
                int comparisonResultBackword = 0;
                for(int j = 0; j < xMasLenght; j++)
                {   
                    // char puzzel = puzzelLine[i + j];
                   if((i+j) < puzzelLine.Length)
                   {
                        if(puzzelLine[i + j] == xMas[j])
                        {
                            comparisonResult ++;
                        }
                        else
                        {
                            break;
                        }
                   }
                }
                if(comparisonResult == xMasLenght)
                {
                    horizontalXmasScore ++;
                    Console.WriteLine("horizonal from right");
                }

                //backword check
                int m = 0;
                for(int k =3; k < xMasLenght && k >= 0; k--)
                {
                    
                    if((i+m) < puzzelLine.Length)
                    {
                        if(puzzelLine[i + m] == xMas[k])
                        {
                            // char puzzel = puzzelLine[i + m];
                            // char xMAsPuzzel = xMas[k];
                            comparisonResultBackword ++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    m ++;

                }
                if(comparisonResultBackword == xMasLenght)
                {
                    horizontalXmasScore ++;
                    Console.WriteLine("Horizontal beckword");
                }
            }
            return horizontalXmasScore;
        }
        //TODO
        private int VerticalXmasPositons(List<string> puzzels)
        {
            int verticalXmasScore = 0;
            int[] row = [1, 2, 3];
            int index = -1; 
            int verticalPartalScore = 0;
            int puzzelNumber = puzzels.Count(); 

            for(int i =0; i < puzzelNumber; i++)
            {
                int n = 0;
                do
                {
                    index = puzzels[i].IndexOf('X', n);
                    // Console.WriteLine($" kolejny x: linia {i} , index: {index}");
                    if(index != -1)
                    {
                        for(int j = 1; j <= row.Length; j++)
                        {
                            if((i+j) < puzzelNumber)
                            {
                                bool fitted = TheSameCharacter(puzzels[i + j], index, xMas[j]);
                                if(fitted)
                                {
                                    verticalPartalScore ++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        if(verticalPartalScore == 3)
                        {
                            verticalXmasScore ++;
                            Console.WriteLine("Vertical");
                        }
                    }
                    n = index +1; 
                    verticalPartalScore = 0;
                }
                while(index != -1 && n <= puzzels[i].Length);
            }
            return verticalXmasScore;
        }

        //TODO
        private int DiagonalXmasPositions(List<string> puzzels)
        {
            int diagonalXmasScore =0;
            int index = -1; 
            int n = 0;
            int nLeft = 0;
            int diaginailPartalScore = 0;
            int puzzelNumber = puzzels.Count(); 
            int[] diadonalPositions = [1, 2, 3];

            for(int i =0; i < puzzelNumber; i++)
            {
                n=0;
                int puzzelCharacters = puzzels[i].Length;
                do
                {
                    index = puzzels[i].IndexOf('X', n);
                    if(index != -1)
                    {
                        for(int j = 1; j <= diadonalPositions.Length; j++)
                        {
                            if((i+j) < puzzelNumber && (index+j) < puzzelCharacters)
                            {
                                bool fitted = TheSameCharacter(puzzels[i + j], index + j, xMas[j]);
                                if(fitted)
                                {
                                    diaginailPartalScore ++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        if(diaginailPartalScore == 3)
                        {
                            diagonalXmasScore ++;
                            Console.WriteLine("Diagonal right");
                        }
                    }
                   n = index + 1; 
                   diaginailPartalScore = 0;
                }
                while (index != -1 && n < puzzelCharacters);

                //check from left to right
                // int puzzelCharacters = puzzels[i].Length;
                nLeft = puzzelCharacters -1;
                do
                {
                    Console.WriteLine(puzzels[i]);
                    index = puzzels[i].LastIndexOf('X', nLeft);

                        if(index != -1)
                        {
                            for(int j = 1; j <= diadonalPositions.Length; j++)
                            {
                                if((i+j) < puzzelNumber && (index-j) >=0)
                                {
                                    bool fitted = TheSameCharacter(puzzels[i + j], index - j, xMas[j]);
                                    if(fitted)
                                    {
                                        diaginailPartalScore ++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                            if(diaginailPartalScore == 3)
                            {
                                diagonalXmasScore ++;
                                Console.WriteLine("Diagonal Left");
                            }
                        }
           
                    
                   nLeft = index -1; 
                   diaginailPartalScore = 0;
                }
                while (index != -1 && nLeft >= 0 && nLeft <  puzzelCharacters);
               

            }
            return diagonalXmasScore;
        }


/// <summary>
/// /Metdoa zwracająca czy przezkazywamnym string puzzel, o indexie index, jest przekazywanym argumnet letter
/// </summary>
/// <param name="puzzel"></param>
/// <param name="index"></param>
/// <param name="letter"></param>
/// <returns></returns>
        private bool TheSameCharacter(string puzzel, int index, char letter)
        {
            bool theSameLetter = false;
               
            char letterResult = puzzel[index];
            if(letter == letterResult)
            {
                theSameLetter = true;
            }
            return theSameLetter;
        }
    }
}
