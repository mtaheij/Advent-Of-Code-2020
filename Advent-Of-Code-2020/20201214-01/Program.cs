using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _20201214_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"PuzzleInput.txt");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Payload here
            string mask = string.Empty;
            Dictionary<long, long> mem = new Dictionary<long, long>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Contains("mask"))
                {
                    mask = input[i].Substring(input[i].IndexOf("=") + 2);
                }
                else
                {
                    int iStart = input[i].IndexOf('[');
                    int iEnd = input[i].IndexOf(']');
                    string sAddress = input[i].Substring(iStart + 1, iEnd - iStart - 1);
                    long lAddress = long.Parse(sAddress);

                    iStart = input[i].IndexOf("= ");
                    long lValue = long.Parse(input[i].Substring(iStart + 2));

                    lValue = ApplyMask(mask, lValue);

                    if (mem.ContainsKey(lAddress))
                    {
                        mem.Remove(lAddress);
                    }
                    mem.Add(lAddress, lValue);
                }
            }

            long lSum = 0;
            foreach (long lValue in mem.Values)
            {
                lSum += lValue;
            }

            sw.Stop();
            Console.WriteLine(String.Format("The sum of all memory places is {0}", lSum));
            Console.WriteLine(String.Format("Elapsed time: {0} ms.", sw.ElapsedMilliseconds.ToString()));
            Console.ReadLine();
        }

        private static long ApplyMask(string mask, long lValue)
        {
            string sValue = Convert.ToString(lValue, 2);
            while (sValue.Length < mask.Length) sValue = "0" + sValue;

            char[] cMask = mask.ToCharArray();
            char[] cValue = sValue.ToCharArray();
            char[] cResulting = new char[mask.Length];

            for (int i = 0; i < mask.Length; i++)
            {
                if (cMask[i] == 'X') cResulting[i] = cValue[i];
                if (cMask[i] == '0') cResulting[i] = '0';
                if (cMask[i] == '1') cResulting[i] = '1';
            }

            string sResulting = new string(cResulting);
            long lResulting = Convert.ToInt64(sResulting, 2);

            return lResulting;
        }
    }
}
