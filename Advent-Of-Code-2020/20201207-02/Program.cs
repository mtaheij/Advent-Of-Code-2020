using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace _20201207_02
{
    class Program
    {
        public static List<string> rules;

        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"..\..\PuzzleInput.txt");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Payload here
            rules = input.ToList();
            int startIndex = rules.FindIndex(x => x.StartsWith("shiny gold bags"));

            int bags = FindBagsInsideStart(startIndex);

            sw.Stop();
            Console.WriteLine(String.Format("Bags: {0}", bags));
            Console.WriteLine(String.Format("Elapsed time: {0} ms.", sw.ElapsedMilliseconds.ToString()));
            Console.ReadLine();
        }

        public static int FindBagsInsideStart(int startIndex)
        {
            string bagRule = rules[startIndex];
            string bagsContainedString = bagRule.Substring(bagRule.IndexOf("contain") + 8).Replace(".", "").Replace("bags", "bag"); //Make all bag names singular so no bags get missed
            string[] bagsInside = bagsContainedString.Split(", ");
            return FindBagsInsideRecursive(bagsInside);
        }


        public static int FindBagsInsideRecursive(string[] bags)
        {
            int total = 0;

            foreach (string bag in bags)
            {
                int amount = int.Parse(bag.Substring(0, bag.IndexOf(" ") + 1));
                string name = bag.Substring(bag.IndexOf(" ") + 1);
                int bagIndex = rules.FindIndex(x => x.StartsWith(name));
                string bagRule = rules[bagIndex];
                bagRule = bagRule.Substring(bagRule.IndexOf("contain") + 8);
                total += amount;

                if (bagRule != "no other bags.")
                {
                    string bagsContainedString = bagRule.Replace(".", "").Replace("bags", "bag"); //Make all bag names singular so no bags get missed
                    string[] bagsInside = bagsContainedString.Split(", ");
                    total += amount * FindBagsInsideRecursive(bagsInside);
                }
            }

            return total;
        }
    }
}