using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _20201207_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"..\..\PuzzleInput.txt");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Payload here
            int bags = 0;
            List<string> bagsChecked = new List<string>();
            string[] bagsToFind = new string[] { "shiny gold bag" };

            while (bagsToFind.Length != 0)
            {
                List<string> newBagsToFind = new List<string>();

                for (int i = 0; i < input.Length; i++)
                {
                    string bagName = input[i].Substring(0, input[i].IndexOf("contain") - 2); //Make all bag names singular so no bags get missed
                    string bagsContainedString = input[i].Substring(input[i].IndexOf("contain"));

                    foreach (string bag in bagsToFind)
                    {
                        if (bagsContainedString.Contains(bag))
                        {
                            if (!bagsChecked.Contains(bagName))
                            {
                                newBagsToFind.Add(bagName);
                                bagsChecked.Add(bagName);
                                bags++;
                            }
                            break;
                        }
                    }
                }

                bagsToFind = newBagsToFind.ToArray();
            }

            sw.Stop();
            Console.WriteLine(String.Format("Bags: {0}", bags));
            Console.WriteLine(String.Format("Elapsed time: {0} ms.", sw.ElapsedMilliseconds.ToString()));
            Console.ReadLine();
        }
    }
}