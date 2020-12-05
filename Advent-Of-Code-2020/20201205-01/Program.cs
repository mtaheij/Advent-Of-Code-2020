using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20201205_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"..\..\PuzzleInput.txt");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Payload here
            int iMaxSeatNumber = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string binRow = input[i].Substring(0, 7);
                string binSeat = input[i].Substring(7, 3);
                int iRow = StringToBinary(binRow);
                int iSeat = StringToBinary(binSeat);

                int iSeatNumber = iRow * 8 + iSeat;
                if (iSeatNumber > iMaxSeatNumber)
                {
                    iMaxSeatNumber = iSeatNumber;
                    Console.WriteLine(input[i] + " : " + iRow + ":" + iSeat + " : " + iSeatNumber);
                }
            }

            sw.Stop();
            Console.WriteLine(String.Format("The highest found seat number is: {0}.", iMaxSeatNumber));
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
    }
}
