using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _20201218_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"PuzzleInput.txt");

            Stack<Operation> operations = new Stack<Operation>();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Payload here
            long total = 0;
            foreach (string line in input)
            {
                operations.Push(new Operation());

                foreach (char c in line.Replace(" ", string.Empty))
                {
                    switch (c)
                    {
                        case '+':
                            operations.Peek().operators.Add('+');
                            break;
                        case '*':
                            operations.Peek().operators.Add('*');
                            break;
                        case '(':
                            operations.Push(new Operation());
                            break;
                        case ')':
                            long final = operations.Peek().calculate();
                            operations.Pop();
                            operations.Peek().numbers.Add(final);
                            if (operations.Peek().operators.Count == 0)
                                operations.Peek().operators.Add('+');
                            break;
                        default:
                            operations.Peek().numbers.Add(int.Parse(c.ToString()));
                            if (operations.Peek().operators.Count == 0)
                                operations.Peek().operators.Add('+');
                            break;
                    }
                }

                total += operations.Pop().calculate();
            }

            Console.WriteLine($"Part 1: {total}");

            sw.Stop();
            Console.WriteLine(String.Format("Elapsed time: {0} ms.", sw.ElapsedMilliseconds.ToString()));
            Console.ReadLine();
        }
    }

    class Operation
    {
        public List<long> numbers = new List<long>();
        public List<char> operators = new List<char>();

        public long calculate()
        {
            long total = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (operators[i] == '+')
                    total += numbers[i];
                else
                    total *= numbers[i];
            }

            return total;
        }
    }
}