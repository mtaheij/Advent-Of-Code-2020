using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace _20201208_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] input = System.IO.File.ReadAllLines(@"PuzzleInput - Example.txt");
            string[] input = System.IO.File.ReadAllLines(@"PuzzleInput.txt");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            int index = 0;
            int iAccumulator = 0;
            List<int> processed = new List<int>();

            // Payload here
            while (true)
            {
                Console.WriteLine(input[index]);

                if (!processed.Contains(index))
                {
                    processed.Add(index);
                }
                else
                {
                    break;
                }

                if (input[index].StartsWith("nop"))
                {
                    index++;
                }
                else if (input[index].StartsWith("acc"))
                {
                    iAccumulator += int.Parse(input[index].Replace("acc", ""));
                    index++;
                }
                else if (input[index].StartsWith("jmp"))
                {
                    index += int.Parse(input[index].Replace("jmp", ""));
                }
            }

            sw.Stop();
            Console.WriteLine(String.Format("The value of the Accumulator is {0}.", iAccumulator));
            Console.WriteLine(String.Format("Elapsed time: {0} ms.", sw.ElapsedMilliseconds.ToString()));
            Console.ReadLine();
        }
    }
}
