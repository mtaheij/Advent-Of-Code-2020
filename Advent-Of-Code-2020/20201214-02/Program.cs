using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _20201214_02
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

                    string sBinaryAddress = Convert.ToString(lAddress, 2);
                    while (sBinaryAddress.Length < mask.Length) sBinaryAddress = "0" + sBinaryAddress;
                    char[] cAddress = sBinaryAddress.ToCharArray();
                    char[] cMask = mask.ToCharArray();
                    char[] cResulting = new char[mask.Length];

                    for (int j = 0; j < mask.Length; j++)
                    {
                        if (cMask[j] == 'X') cResulting[j] = 'X';
                        if (cMask[j] == '0') cResulting[j] = cAddress[j];
                        if (cMask[j] == '1') cResulting[j] = '1';
                    }

                    string sResulting = new string(cResulting);

                    put(sResulting, lValue, mem);
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

        private static void put(string mask, long value, Dictionary<long, long> mem)
        {
            if (!mask.Contains("X"))
            {
                long lAddress = Convert.ToInt64(mask, 2);
                if (mem.ContainsKey(lAddress))
                {
                    mem.Remove(lAddress);
                }
                mem.Add(lAddress, value);
                return;
            }
            put(ReplaceFirst(mask, "X", "0"), value, mem);
            put(ReplaceFirst(mask, "X", "1"), value, mem);
        }
 
        private static string ReplaceFirst(string input, string search, string replace)
        {
            int iPos = input.IndexOf(search);

            if (iPos >= 0)
            {
                string retVal = input.Substring(0, iPos) + replace + input.Substring(iPos + 1, input.Length - iPos - 1);
                return retVal;
            }
            else
                return input;
        }
    }
}
