using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20201203_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"..\..\PuzzleInput.txt");

            int slopeX = 3;
            int slopeY = 1;
            int patternLength = input[1].Length;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Payload here
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

            sw.Stop();
            Console.WriteLine(String.Format("There are {0} trees encountered", numTrees));
            Console.WriteLine(String.Format("Elapsed time: {0} ms.", sw.ElapsedMilliseconds.ToString()));
            Console.ReadLine();
        }
    }
}
