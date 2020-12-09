using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _20201209_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"PuzzleInput.txt");

            int preAmble = 25;
            int sumIndex = 0;
            int sumToFind = 0;

            int lowestValue = 0;
            int highestValue = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Payload here
            for (int i = preAmble; i < input.Length; i++)
            {
                List<int> numbersToAdd = new List<int>();
                for (int j = i - preAmble; j < i; j++)
                {
                    numbersToAdd.Add(int.Parse(input[j]));
                }
                sumToFind = int.Parse(input[i]);

                if (!FindSum(numbersToAdd, sumToFind))
                {
                    Console.WriteLine(String.Format("First number that is not a sum of the previous {0} numbers is {1}. It is at index {2}", preAmble, sumToFind, i));
                    sumIndex = i;
                    break;
                }
            }

            // Now that we have found the errorneous sum, find a list of subsequent numbers that do add up to this
            if (sumIndex > 0 && sumToFind > 0)
            {
                for (int i = 0; i < sumIndex; i++)
                {
                    int sumSoFar = int.Parse(input[i]);
                    lowestValue = sumSoFar;
                    highestValue = sumSoFar;

                    int j = i + 1;
                    while (j < sumIndex && sumSoFar < sumToFind)
                    {
                        sumSoFar += int.Parse(input[j]);

                        if (int.Parse(input[j]) < lowestValue)
                        {
                            lowestValue = int.Parse(input[j]);
                        }
                        if (int.Parse(input[j]) > highestValue)
                        {
                            highestValue = int.Parse(input[j]);
                        }
                        j++;
                    }

                    if (sumSoFar == sumToFind)
                    {
                        break;
                    }
                }
            }

            if (sumIndex > 0 && sumToFind > 0)
            {
                Console.WriteLine(String.Format("The lowest number in the range is {0} and the highest number is {1}. The sum is {2}", lowestValue, highestValue, lowestValue + highestValue));
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
