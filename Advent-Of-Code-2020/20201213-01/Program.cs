using System;
using System.Diagnostics;

namespace _20201213_01
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

            foreach (string bus in busses)
            {
                if (!bus.Equals("x"))
                {
                    double busId = double.Parse(bus);
                    if (busId == 13)
                    {
                        Debugger.Break();
                    }

                    double departuresSinceStart = earliestTimeStamp / busId;
                    double nextDeparture = (departuresSinceStart + 1) * busId;

                    if (nextDeparture < nextPossibleDeparture)
                    {
                        nextPossibleDeparture = nextDeparture;
                        busIdToTake = busId;
                    }
                }
            }

            sw.Stop();

            Console.WriteLine(String.Format("Your earliest departure is {0}", nextPossibleDeparture.ToString()));
            double answer = (nextPossibleDeparture - earliestTimeStamp - 1) * busIdToTake;
            Console.WriteLine(String.Format("The bus Id is {0}, you'll have to wait {1} minutes. The answer is {2}", busIdToTake, nextPossibleDeparture - earliestTimeStamp - 1, answer));
            Console.WriteLine(String.Format("Elapsed time: {0} ms.", sw.ElapsedMilliseconds.ToString()));
            Console.ReadLine();
        }
    }
}
