using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _20201204_02
{
    class Program
    {
        static void Main(string[] args)
        {
            // Answer 1: 225 (too high)

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

                numPassports++;
                if (CheckPassport(credsThisLine))
                {
                    numCorrectPassports++;
                }
            }

            sw.Stop();
            Console.WriteLine(String.Format("There are {0} passports", numPassports));
            Console.WriteLine(String.Format("Of which {0} are valid", numCorrectPassports));
            Console.WriteLine(String.Format("Elapsed time: {0} ms.", sw.ElapsedMilliseconds.ToString()));
            Console.ReadLine();
        }

        private static string EYECOLOR_PATTERN = "^amb|blu|brn|gry|grn|hzl|oth$";
        private static string HEX_HAIRCOLOR_PATTERN = "^(#[a-fA-F0-9]{6})$";
        private static string PID_PATTERN = "^([0-9]{9})$";
        private static string EXPIRATION_PATTERN = "^(202[0-9]|2030)$";
        private static string HEIGHT_PATTERN = "^([0-9]{3}cm|[0-9]{2}in)$";
        static bool CheckPassport(List<string> creds)
        {
            bool ecl = false, pid = false, eyr =false, hcl = false, byr = false, iyr = false, hgt = false, cid = false;

            foreach (string s in creds)
            {
                string[] pair = s.Split(':');

                if (pair[0] == "ecl")
                {
                    if (Regex.IsMatch(pair[1], EYECOLOR_PATTERN))
                    {
                        ecl = true;
                    }
                }

                if (pair[0] == "pid")
                {
                    if (Regex.IsMatch(pair[1], PID_PATTERN))
                    {
                        pid = true;
                    }
                }

                if (pair[0] == "eyr")
                {
                    if (Regex.IsMatch(pair[1], EXPIRATION_PATTERN))
                    {
                        eyr = true;
                    }
                }

                if (pair[0] == "hcl")
                {
                    if (Regex.IsMatch(pair[1], HEX_HAIRCOLOR_PATTERN))
                    {
                        hcl = true;
                    }
                }

                if (pair[0] == "byr")
                {
                    if (int.Parse(pair[1]) >= 1920 && int.Parse(pair[1]) <= 2002)
                    {
                        byr = true;
                    }
                }

                if (pair[0] == "iyr")
                {
                    if (int.Parse(pair[1]) >= 2010 && int.Parse(pair[1]) <= 2020)
                    {
                        iyr = true;
                    }
                }

                if (pair[0] == "hgt")
                {
                    if (Regex.IsMatch(pair[1], HEIGHT_PATTERN))
                    {
                        int height = int.Parse(pair[1].Replace("cm", "").Replace("in", ""));
                        if (pair[1].EndsWith("cm") && height >= 150 && height <= 193)
                        {
                            hgt = true;                         
                        }
                        if (pair[1].EndsWith("in") && height >= 59 && height <= 76)
                        {
                            hgt = true;
                        }
                    }
                }

                if (pair[0] == "cid")
                {
                    cid = true;
                }
            }

            if (ecl && pid && eyr && hcl && byr && iyr && hgt)
            {
                return true;
            }

            return false;
        }
    }
}
