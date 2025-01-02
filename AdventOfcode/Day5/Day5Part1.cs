
namespace Day5
{
    public class Day5Part1
    {
        string line;
        List<string> codePuzzle = new List<string>();

        // string csvFile = "Day5/test4.csv";
        string csvFile = "testData.csv";

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
    }
}
