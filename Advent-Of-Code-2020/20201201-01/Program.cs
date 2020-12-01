using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20201201_01
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
                    int inti = int.Parse(input[i]);
                    int intj = int.Parse(input[j]); 
                    Console.WriteLine(String.Format("{0},{1}:{2}+{3}={4}", i, j, inti, intj, inti + intj));
                    
                    if (inti + intj == 2020)
                    {
                        Console.WriteLine(String.Format("The numbers {0} and {1} sum up to 2020, when multiplied, this gives {2}", inti, intj, inti * intj));
                        Console.ReadLine();
                        break;
                    }
                }
            }    
            Console.ReadLine();
        }
    }
}
