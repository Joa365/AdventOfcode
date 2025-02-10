using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode
{
    public class Day2
    {
        //Open file and  read data from file
        private void LoadDataFromCsV()
        {
            var data = new List<string>();
        // var configuration = new CsvConfiguration()
        }
        private bool SartedString(string input)
        {
            bool sorted = false;

            var orderedInput = string.Join(" ", input.OrderBy( i => int.Parse(i.ToString())));

            if (input == orderedInput)
            {
                Console.WriteLine("it's sarted.");
                sorted = true;
            }
            else
            {
                Console.WriteLine("it's not sorted");
            }
                return sorted;
        }

        //Check if any two adjacent levels differ by at least one and at most three.
        private bool SafeLevelDiffet(string input)
        {
            
            bool safeLevelDiffet = true;

            //Rozdzielanie liczb i przekazywanie ich de tablicy s
            string[] numbers = input.Split(new char[]{' '});

            for (int i=0; i<numbers.Count(); i++)
            {
                if (i < numbers.Count()-1)
                {
                    int result = Math.Abs(int.Parse(numbers[i]) - int.Parse(numbers[i +1]));
                    Console.WriteLine(result); 
                    if (result == 0 || result > 3)
                    {
                        safeLevelDiffet = false;
                    }

                }

            }

            return safeLevelDiffet; 
        }
    }

}
    