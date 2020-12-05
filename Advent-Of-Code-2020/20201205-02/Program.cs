using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20201205_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"..\..\PuzzleInput.txt");
            string[,] seats = new string[127, 8];
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < 127; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    seats[i, j] = ".";
                }
            }
            // Payload here

            for (int i = 0; i < input.Length; i++)
            {
                string binRow = input[i].Substring(0, 7);
                string binSeat = input[i].Substring(7, 3);
                int iRow = StringToBinary(binRow);
                int iSeat = StringToBinary(binSeat);

                int iSeatNumber = iRow * 8 + iSeat;

                seats[iRow, iSeat] = "X";
            }

            sw.Stop();

            DisplaySeats(seats);

            int iMySeat = FindSeat(seats);
            Console.WriteLine(String.Format("My seat number is {0}.", iMySeat));
            Console.WriteLine(String.Format("Elapsed time: {0} ms.", sw.ElapsedMilliseconds.ToString()));
            Console.ReadLine();
        }

        static int StringToBinary(string input)
        {
            int retVal = 0;
            char[] chars = input.ToCharArray();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (chars[i].Equals('B') || chars[i].Equals('R'))
                {
                    retVal += (int)Math.Pow(2, input.Length - i - 1);
                }
            }
            return retVal;
        }

        static void DisplaySeats(string[,] seats)
        {
            for (int i = 0; i < 31; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(seats[i, j]);
                }
                Console.Write("    ");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(seats[i + 32, j]);
                }
                Console.Write("    ");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(seats[i + 64, j]);
                }
                Console.Write("    ");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(seats[i + 96, j]);
                }
                Console.WriteLine();
            }
        }

        static int FindSeat(string[,] seats)
        {
            int iMySeat = 0;

            for (int i = 1; i < 127; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (!seats[i,j].Equals("X"))
                    {
                        iMySeat = i * 8 + j;
                        break;
                    }
                }
                if (iMySeat > 0)
                {
                    break;
                }
            }

            return iMySeat;
        }
    }
}
