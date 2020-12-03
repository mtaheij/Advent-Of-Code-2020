using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _20201202_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"..\..\PuzzleInput.txt");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            int numOk = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string[] parts = input[i].Split('-', ' ', ':');
                int min = int.Parse(parts[0]);
                int max = int.Parse(parts[1]);
                string c = parts[2];
                string password = parts[4];

                if (TestPassword(min, max, c, password))
                {
                    //Console.WriteLine(String.Format("Password '{0}' is a valid password", password));
                    numOk++;
                }
            }

            sw.Stop();
            Console.WriteLine(String.Format("There are {0} passwords that are valid", numOk));
            Console.WriteLine(String.Format("Elapsed time: {0} ms.", sw.ElapsedMilliseconds.ToString()));
            Console.ReadLine();
        }

        static bool TestPassword(int min, int max, string c, string password)
        {
            int count = Regex.Matches(password, c).Count;
            if (count >= min && count <= max)
                return true;
            return false;
        }
    }
}
