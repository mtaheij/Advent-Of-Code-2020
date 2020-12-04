using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20201204_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"..\..\PuzzleInput.txt");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            int numPassports = 0;
            int numCorrectPassports = 0;
            List<string> credsThisPassport = new List<string>();

            // Payload here
            for (int i = 0; i < input.Length; i++)
            {
                List<string> credsThisLine = input[i].Split(' ').ToList();

//                numPassports++;
//                if (CheckPassport(credsThisLine))
//                {
//                    numCorrectPassports++;
//                }

                if (credsThisLine.Count == 0 || (string.IsNullOrWhiteSpace(input[i])))
                {
                    if (credsThisPassport.Count > 0)
                    {
                        numPassports++;
                        Console.WriteLine(String.Format("Passport {0} contains {1} credentials", numPassports, credsThisPassport.Count));
                    }

                    if (CheckPassport(credsThisPassport))
                    {
                        numCorrectPassports++;
                    }
                    credsThisPassport = new List<string>();
                }

                if (!string.IsNullOrWhiteSpace(input[i]))
                {
                    credsThisPassport.AddRange(credsThisLine);
                }
            }

            sw.Stop();
            Console.WriteLine(String.Format("There are {0} passports", numPassports));
            Console.WriteLine(String.Format("Of which {0} are valid", numCorrectPassports));
            Console.WriteLine(String.Format("Elapsed time: {0} ms.", sw.ElapsedMilliseconds.ToString()));
            Console.ReadLine();
        }

        static bool CheckPassport(List<string> creds)
        {
            bool ecl = false;
            bool pid = false;
            bool eyr = false;
            bool hcl = false;
            bool byr = false;
            bool iyr = false;
            bool hgt = false;
            bool cid = false;

            foreach (string s in creds)
            {
                string[] pair = s.Split(':');

                if (pair[0] == "ecl") ecl = true;
                if (pair[0] == "pid") pid = true;
                if (pair[0] == "eyr") eyr = true;
                if (pair[0] == "hcl") hcl = true;
                if (pair[0] == "byr") byr = true;
                if (pair[0] == "iyr") iyr = true;
                if (pair[0] == "hgt") hgt = true;
                if (pair[0] == "cid") cid = true;
            }

            if (ecl && pid && eyr && hcl && byr && iyr && hgt)
            {
                return true;
            }

            return false;
        }
    }
}
