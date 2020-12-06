using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20201206_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"..\..\PuzzleInput.txt");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            int numQuestions = 0;
            int numPeople = 0;
            List<char> questions = new List<char>();

            // Payload here
            for (int i = 0; i < input.Length; i++)
            {
                string thisLine = input[i];
                if (string.IsNullOrWhiteSpace(thisLine))
                {
                    numQuestions += CheckQuestions(questions, numPeople);
                    questions = new List<char>();
                    numPeople = 0;
                }

                if (!string.IsNullOrWhiteSpace(thisLine)) numPeople++;

                char[] separate = thisLine.ToCharArray();
                foreach (char c in separate)
                {
                    questions.Add(c);
                }
            }

            numQuestions += CheckQuestions(questions, numPeople);

            sw.Stop();
            Console.WriteLine(string.Format("There are {0} questions answered by the different groups", numQuestions));
            Console.WriteLine(String.Format("Elapsed time: {0} ms.", sw.ElapsedMilliseconds.ToString()));
            Console.ReadLine();
        }

        static string alphabet = "abcdefghijklmnopqrstuvwxyz";

        static int CheckQuestions(List<char> questions, int numPeople)
        {
            int retVal = 0;

            foreach (char c in alphabet.ToCharArray())
            {
                if (questions.Where(x => x == c).Count() == numPeople) retVal++;
            }

            return retVal;
        }
    }
}
