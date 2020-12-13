using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _20201213_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"PuzzleInput.txt");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Payload here
            double earliestTimeStamp = double.Parse(input[0]);
            string busIds = input[1];
            string[] busses = busIds.Split(",");
            double nextPossibleDeparture = 99999999;
            double busIdToTake = 0;
            long product = 1;
            long[] ids = new long[busses.Length];
            long b = 0;

            for (int i = 0; i < busses.Length; i++)
            {
                string bus = busses[i];
                if (!bus.Equals("x"))
                {
                    long busId = long.Parse(bus);

                    product *= busId;
                    ids[i] = busId;

                    double departuresSinceStart = earliestTimeStamp / busId;
                    double nextDeparture = (departuresSinceStart + 1) * busId;

                    if (nextDeparture < nextPossibleDeparture)
                    {
                        nextPossibleDeparture = nextDeparture;
                        busIdToTake = busId;
                    }
                }
            }

            long p, sm = 0;
            for (int i = 0; i< busses.Length; i++)
            {
                if (ids[i] != 0)
                {
                    p = product / ids[i];
                    sm += (ids[i] - i) * NumberUtils.mulInv(p, ids[i]) * p;
                }

            }

            b = sm % product;

            sw.Stop();

            Console.WriteLine(String.Format("The answer is {0}", b));
            Console.WriteLine(String.Format("Elapsed time: {0} ms.", sw.ElapsedMilliseconds.ToString()));
            Console.ReadLine();
        }
    }
}
