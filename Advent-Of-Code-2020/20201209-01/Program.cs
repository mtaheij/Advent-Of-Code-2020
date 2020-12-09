using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _20201209_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"PuzzleInput.txt");

            int preAmble = 25;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Payload here
            for (int i = preAmble; i < input.Length; i++)
            {
                List<int> numbersToAdd = new List<int>();
                for (int j = i - preAmble; j< i; j++)
                {
                    numbersToAdd.Add(int.Parse(input[j]));
                }
                int sumToFind = int.Parse(input[i]);

                if (!FindSum(numbersToAdd, sumToFind))
                {
                    Console.WriteLine(String.Format("First number that is not a sum of the previous {0} numbers is {1}", preAmble, sumToFind));
                    break;
                }
            }

            sw.Stop();
            Console.WriteLine(String.Format("Elapsed time: {0} ms.", sw.ElapsedMilliseconds.ToString()));
            Console.ReadLine();
        }

        static bool FindSum(List<int> numbersToAdd, int sumToFind)
        {
            int[] iNumbers = numbersToAdd.ToArray();
            bool sumFound = false;

            for (int i = 0; i < iNumbers.Length; i++)
            {
                for (int j = i + 1; j < iNumbers.Length; j++)
                {
                    if (iNumbers[i] + iNumbers[j] == sumToFind)
                    {
                        sumFound = true;
                        break;
                    }
                }
                if (sumFound)
                {
                    break;
                }
            }

            return sumFound;
        }
    }
}
