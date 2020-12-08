using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _20201208_02
{
    class Program
    {
        static int iLastSwapped;
        static string[] instructions = new string[612];

        static void Main(string[] args)
        {
            //string[] input = System.IO.File.ReadAllLines(@"PuzzleInput - Example.txt");
            string[] input = System.IO.File.ReadAllLines(@"PuzzleInput.txt");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Payload here
            iLastSwapped = input.Length - 1;

            int index = 0;
            int iAccumulator = 0;
            List<int> processed = new List<int>();
            ResetInstructions(input);

            while (iLastSwapped > 0)
            {
                if (index == input.Length)
                {
                    break;
                }
                //Console.WriteLine(instructions[index]);

                if (!processed.Contains(index))
                {
                    processed.Add(index);
                }
                else
                {
                    //Console.WriteLine("We went into a loop");
                    ResetInstructions(input); // Reset everything
                    index = 0;
                    processed = new List<int>();
                    processed.Add(0);
                    iAccumulator = 0;

                    ChangeInstruction(); // Swap the latest instruction that may cause a loop and remember where we did this
                }

                if (instructions[index].StartsWith("nop"))
                {
                    index++;
                }
                else if (instructions[index].StartsWith("acc"))
                {
                    iAccumulator += int.Parse(instructions[index].Replace("acc", ""));
                    index++;
                }
                else if (instructions[index].StartsWith("jmp"))
                {
                    index += int.Parse(instructions[index].Replace("jmp", ""));
                }
            }

            sw.Stop();
            Console.WriteLine(String.Format("The value of the Accumulator is {0}.", iAccumulator));
            Console.WriteLine(String.Format("Elapsed time: {0} ms.", sw.ElapsedMilliseconds.ToString()));
            Console.ReadLine();
        }

        private static void ChangeInstruction()
        {
            for (int i = iLastSwapped - 1; i > 0; i--)
            {
                if (instructions[i].StartsWith("jmp"))
                {
                    instructions[i] = instructions[i].Replace("jmp", "nop");
                    Console.WriteLine(String.Format("Changed instruction at {0} from jmp to nop.", i));
                    iLastSwapped = i;
                    break; 
                }

                if (instructions[i].StartsWith("nop"))
                {
                    instructions[i] = instructions[i].Replace("nop", "jmp");
                    Console.WriteLine(String.Format("Changed instruction at {0} from nop to jmp.", i));
                    iLastSwapped = i;
                    break;
                }
            }
        }

        private static void ResetInstructions(string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                instructions[i] = input[i];
            }
        }
    }
}
