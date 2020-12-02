using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20201203_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"..\..\PuzzleInput.txt");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Payload here
            int numOk = 0;

            sw.Stop();
            Console.WriteLine(String.Format("There are {0} passwords that are valid", numOk));
            Console.WriteLine(String.Format("Elapsed time: {0} ms.", sw.ElapsedMilliseconds.ToString()));
            Console.ReadLine();
        }
    }
}
