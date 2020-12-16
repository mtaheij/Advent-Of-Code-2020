using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _20201216_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"PuzzleInput.txt");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Payload here
            Dictionary<string, List<int>> validnumbers = new Dictionary<string, List<int>>();
            List<int> validAll = new List<int>();

            int r = 0;
            do
            {
                string inp = input[r];
                if (!string.IsNullOrWhiteSpace(inp))
                {
                    string[] parts = inp.Split(':');
                    string sKey = parts[0];

                    string[] pairs = parts[1].Split(' ');
                    string[] firstPair = pairs[1].Split('-');
                    string[] secondPair = pairs[3].Split('-');

                    int minFirst = int.Parse(firstPair[0]);
                    int maxFirst = int.Parse(firstPair[1]);
                    int minSecond = int.Parse(secondPair[0]);
                    int maxSecond = int.Parse(secondPair[1]);

                    List<int> numbers = new List<int>();

                    for (int a = minFirst; a <= maxFirst; a++)
                    {
                        numbers.Add(a);
                        validAll.Add(a);
                    }
                    for (int a = minSecond; a <= maxSecond; a++)
                    {
                        numbers.Add(a);
                        validAll.Add(a);
                    }

                    validnumbers.Add(sKey, numbers);
                }

                r++;
            } while (!input[r].Equals("your ticket:"));

            int tser = 0;

            for (int i = r+4; i < input.Length; i++)
            {
                string[] values = input[i].Split(',');

                foreach (string s in values)
                {
                    int val = int.Parse(s);
                    if (validAll.Contains(val))
                    {

                    }
                    else
                    {
                        tser += val;
                    }
                }
            }

            sw.Stop();
            Console.WriteLine(String.Format("The answer is: {0}.", tser));
            Console.WriteLine(String.Format("Elapsed time: {0} ms.", sw.ElapsedMilliseconds.ToString()));
            Console.ReadLine();
        }
    }
}
