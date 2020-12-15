using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _20201215_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"PuzzleInput.txt");
            string[] sInput = input[0].Split(',');
            List<long> nums = new List<long>();

            foreach (string s in sInput)
            {
                nums.Add(long.Parse(s));
            }

            Dictionary<long, long> done = new Dictionary<long, long>();
            long answer = -1;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Payload here
            long prev = 0;
            long i = 0;
            foreach (long num in nums)
            {
                done.Add(num, ++i);
                prev = num;
            }

            while (i < 30000000)
            {
                long diff = i - done.GetValueOrDefault(prev, i);
                done.Remove(prev);
                done.Add(prev, i++);
                prev = diff;

                if (i == 2020)
                {
                    answer = prev;
                    break;
                }
            }
            sw.Stop();
            Console.WriteLine(String.Format("The 2020th called number is: {0}.", answer));
            Console.WriteLine(String.Format("Elapsed time: {0} ms.", sw.ElapsedMilliseconds.ToString()));
            Console.ReadLine();
        }
    }
}
