using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace AdventOfcode
{

    public class Day3Part1
    {
        List<string> codeList = new List<string>();
        List<string> slectMul = new List<string>();
        string line;
        int score = 0;

        string csvFile = "data3.csv";
        // string csvFile = "testData.csv";

        public void ReadDataFromCsvFile()
        {
            // file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(csvFile);
            //Read the first line of text
            line = sr.ReadLine();
            //Continue to read until you reach end of file
            while (line != null)
            {
                //write the line to console window
                //Console.WriteLine(line)
                
                    codeList.Add(line);
                //Read the next line
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();

            foreach(var item in codeList)
            {
                // Console.WriteLine(item);
                score += SelectChainOfCode(item);
            }
            Console.WriteLine($"Score: {score}");

            SplitLine(codeList);
        }   

        private void SplitLine(List<string> codedMul)
        {

        }
        private int SelectChainOfCode(string line)
        {
             List<(int n1, int n2)> numbers = new List<(int n1, int n2)>();
            string[] sentences = line.Split("mul(");
            int scoreFromLine = 0;

            for( int i = 0; i < sentences.Length; i++)
            {
                List<string> temp = new(); 
                int number1 = 0;
                int number2 = 0;
                string mulSentense;

                mulSentense = sentences[i].ToString();
           
                // if(!string.IsNullOrEmpty(mulSentense) && !string.IsNullOrWhiteSpace(mulSentense))
                // {
                    //  Console.WriteLine(mulSentense);
                    for(int j=0; j < mulSentense.Length; j++)
                    {
                        char sing = mulSentense[j];
                        // Console.WriteLine(sing);
                        //sprawdzam czy char jest liczba
                        
                        if(Char.IsDigit(sing))
                        {
                            temp.Add(sing.ToString());
                        }
                        else if(sing == ',')
                        {
                            if(temp.Count>0)
                            {
                                number1 = Int32.Parse(string.Join("", temp));
                                temp.Clear();
                            }
                        }
                        else if(sing == ')')
                        {
                            if(temp.Count>0)
                            {
                                number2 = Int32.Parse(string.Join("", temp));
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                     }
                       if(number1 != 0 && number2 !=0)
                       {
                            numbers.Add((n1: number1, n2: number2));
                            // Console.WriteLine($"{number1} , {number2}");
                       }
                    
                // }
            }
        
            foreach(var number in numbers)
            {
                // Console.WriteLine($"{number.n1}, {number.n2}");
                scoreFromLine +=(number.n1 * number.n2);

            }
           return scoreFromLine; 
        }
    }
}   