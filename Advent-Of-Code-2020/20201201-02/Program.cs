using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20201201_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"..\..\PuzzleInput.txt");

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    for (int k = j + 1; k < input.Length; k++)
                    {
                        int inti = int.Parse(input[i]);
                        int intj = int.Parse(input[j]);
                        int intk = int.Parse(input[k]);
 //                       Console.WriteLine(String.Format("{0},{1},{2}:{3}+{4}+{5}={6}", i, j, k, inti, intj, intk, inti + intj + intk));

                        if (inti + intj + intk == 2020)
                        {
                            Console.WriteLine(String.Format("The numbers {0}, {1} and {2} sum up to 2020, when multiplied, this gives {3}", inti, intj, intk, inti * intj * intk));
                            Console.ReadLine();
                            break;
                        }
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
