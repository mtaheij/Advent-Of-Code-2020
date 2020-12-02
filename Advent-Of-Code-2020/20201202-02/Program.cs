using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _20201202_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"..\..\PuzzleInput.txt");
            int numOk = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string[] parts = input[i].Split('-', ' ', ':');
                int pos1 = int.Parse(parts[0]);
                int pos2 = int.Parse(parts[1]);
                string c = parts[2];
                string password = parts[4];

                if (TestPassword(pos1, pos2, c, password))
                {
                    Console.WriteLine(String.Format("Password '{0}' is a valid password", password));
                    numOk++;
                }
            }

            Console.WriteLine(String.Format("There are {0} passwords that are valid", numOk));
            Console.ReadLine();
        }

        static bool TestPassword(int pos1, int pos2, string c, string password)
        {
            bool b1 = false;
            bool b2 = false;
            if (password.Substring(pos1 - 1, 1) == c) b1 = true;
            if (password.Substring(pos2 - 1, 1) == c) b2 = true;

            if (b1 == true && b2 == false) return true;
            if (b1 == false && b2 == true) return true;
            return false;
        }
    }
}
