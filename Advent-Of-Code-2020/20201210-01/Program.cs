using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _20201210_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"PuzzleInput.txt");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Payload here
            List<int> adapters = new List<int>();
            foreach (string s in input)
            {
                adapters.Add(int.Parse(s));
            }
            adapters.Sort();

            int lastJolt = 0;
            int num1step = 0;
            int num3step = 0;
            foreach (int i in adapters)
            {
                if (i - 1 == lastJolt) num1step++;
                if (i - 3 == lastJolt) num3step++;

                lastJolt = i;
            }
            num3step++; // The final adapter is always 3 Jolts higher

            sw.Stop();
            Console.WriteLine(String.Format("There are {0} 1-Jolt differences and {1} 3-Jolt differences", num1step, num3step));
            Console.WriteLine(String.Format("The answer is: {0}", num1step * num3step));
            Console.WriteLine(String.Format("Elapsed time: {0} ms.", sw.ElapsedMilliseconds.ToString()));
            Console.ReadLine();
        }
    }
}
