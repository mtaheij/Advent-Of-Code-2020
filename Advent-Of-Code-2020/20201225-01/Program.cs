using System;
using System.Diagnostics;

namespace _20201225_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"PuzzleInput.txt");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Payload here
            string s1 = DoWork(input[0], input[1]);

            sw.Stop();
            Console.WriteLine(String.Format("The answer is: {0}.", s1));
            Console.WriteLine(String.Format("Elapsed time: {0} ms.", sw.ElapsedMilliseconds.ToString()));
            Console.ReadLine();
        }

        public static string DoWork(string input1, string input2)
        {
            long cardPK = long.Parse(input1), doorPK = long.Parse(input2);
            long cardLoop = findLoop(cardPK), doorLoop = findLoop(doorPK);
            long cardEncryptionKey = getEK(doorPK, cardLoop), doorEncryptionKey = getEK(cardPK, doorLoop);

            if (cardEncryptionKey != doorEncryptionKey)
                return "Oops - something went wrong";
            else
                return cardEncryptionKey.ToString();
        }

        private static long findLoop(long pk)
        {
            long value = 1, loopNo = 0;
            while (value != pk)
            {
                value = doCalc(value, 7);
                loopNo++;
            }
            return loopNo;
        }

        private static long getEK(long pk, long loopNo)
        {
            long value = 1;
            for (long i = 0; i < loopNo; i++)
                value = doCalc(value, pk);
            return value;
        }

        private static long doCalc(long value, long seed)
        {
            value *= seed;
            value %= 20201227;
            return value;
        }
    }
}
