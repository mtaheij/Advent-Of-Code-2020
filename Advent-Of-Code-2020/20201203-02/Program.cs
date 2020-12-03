using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20201203_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"..\..\PuzzleInput.txt");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Payload here
            int numTrees1 = CountTrees(input, 1, 1);
            Console.WriteLine(String.Format("There are {0} trees encountered for slope = 1,1", numTrees1));

            int numTrees2 = CountTrees(input, 3, 1);
            Console.WriteLine(String.Format("There are {0} trees encountered for slope = 3,1", numTrees2));

            int numTrees3 = CountTrees(input, 5, 1);
            Console.WriteLine(String.Format("There are {0} trees encountered for slope = 5,1", numTrees3));

            int numTrees4 = CountTrees(input, 7, 1);
            Console.WriteLine(String.Format("There are {0} trees encountered for slope = 7,1", numTrees4));

            int numTrees5 = CountTrees(input, 1, 2);
            Console.WriteLine(String.Format("There are {0} trees encountered for slope = 1,2", numTrees5));

            sw.Stop();
            Console.WriteLine(String.Format("The answer = {0}", numTrees1 * numTrees2 * numTrees3 * numTrees4 * numTrees5));
            Console.WriteLine(String.Format("Elapsed time: {0} ms.", sw.ElapsedMilliseconds.ToString()));
            Console.ReadLine();
        }

        static int CountTrees(string[] input, int slopeX, int slopeY)
        {
            int patternLength = input[0].Length;
            int lineNum = 0;
            int colNum = 0;

            int numTrees = 0;

            while (lineNum < input.Length)
            {
                colNum += slopeX;
                if (colNum >= patternLength)
                {
                    colNum -= patternLength;
                }

                lineNum += slopeY;

                if (lineNum < input.Length)
                {
                    if (input[lineNum].Substring(colNum, 1) == "#" || input[lineNum].Substring(colNum, 1) == "X")
                    {
                        numTrees++;
                    }
                }
            }

            return numTrees;
        }
    }
}
