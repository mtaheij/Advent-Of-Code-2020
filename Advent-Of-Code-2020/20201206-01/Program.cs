using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20201206_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"..\..\PuzzleInput.txt");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            long numQuestions = 0;
            string questions = "abcdefghijklmnopqrstuvwxyz";

            // Payload here
            for (int i = 0; i < input.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(input[i]))
                {
                    numQuestions += CheckQuestions(questions);
                    questions = "abcdefghijklmnopqrstuvwxyz";
                }

                if (input[i].Contains("a")) questions = questions.Replace("a", "A");
                if (input[i].Contains("b")) questions = questions.Replace("b", "B");
                if (input[i].Contains("c")) questions = questions.Replace("c", "C");
                if (input[i].Contains("d")) questions = questions.Replace("d", "D");
                if (input[i].Contains("e")) questions = questions.Replace("e", "E");
                if (input[i].Contains("f")) questions = questions.Replace("f", "F");
                if (input[i].Contains("g")) questions = questions.Replace("g", "G");
                if (input[i].Contains("h")) questions = questions.Replace("h", "H");
                if (input[i].Contains("i")) questions = questions.Replace("i", "I");
                if (input[i].Contains("j")) questions = questions.Replace("j", "J");
                if (input[i].Contains("k")) questions = questions.Replace("k", "K");
                if (input[i].Contains("l")) questions = questions.Replace("l", "L");
                if (input[i].Contains("m")) questions = questions.Replace("m", "M");
                if (input[i].Contains("n")) questions = questions.Replace("n", "N");
                if (input[i].Contains("o")) questions = questions.Replace("o", "O");
                if (input[i].Contains("p")) questions = questions.Replace("p", "P");
                if (input[i].Contains("q")) questions = questions.Replace("q", "Q");
                if (input[i].Contains("r")) questions = questions.Replace("r", "R");
                if (input[i].Contains("s")) questions = questions.Replace("s", "S");
                if (input[i].Contains("t")) questions = questions.Replace("t", "T");
                if (input[i].Contains("u")) questions = questions.Replace("u", "U");
                if (input[i].Contains("v")) questions = questions.Replace("v", "V");
                if (input[i].Contains("w")) questions = questions.Replace("w", "W");
                if (input[i].Contains("x")) questions = questions.Replace("x", "X");
                if (input[i].Contains("y")) questions = questions.Replace("y", "Y");
                if (input[i].Contains("z")) questions = questions.Replace("z", "Z");
            }

            numQuestions += CheckQuestions(questions);

            sw.Stop();
            Console.WriteLine(string.Format("There are {0} questions answered by the different groups", numQuestions));
            Console.WriteLine(String.Format("Elapsed time: {0} ms.", sw.ElapsedMilliseconds.ToString()));
            Console.ReadLine();
        }

        static int CheckQuestions(string questions)
        {
            int retVal = 0;

            if (questions.Contains("A")) retVal++;
            if (questions.Contains("B")) retVal++;
            if (questions.Contains("C")) retVal++;
            if (questions.Contains("D")) retVal++;
            if (questions.Contains("E")) retVal++;
            if (questions.Contains("F")) retVal++;
            if (questions.Contains("G")) retVal++;
            if (questions.Contains("H")) retVal++;
            if (questions.Contains("I")) retVal++;
            if (questions.Contains("J")) retVal++;
            if (questions.Contains("K")) retVal++;
            if (questions.Contains("L")) retVal++;
            if (questions.Contains("M")) retVal++;
            if (questions.Contains("N")) retVal++;
            if (questions.Contains("O")) retVal++;
            if (questions.Contains("P")) retVal++;
            if (questions.Contains("Q")) retVal++;
            if (questions.Contains("R")) retVal++;
            if (questions.Contains("S")) retVal++;
            if (questions.Contains("T")) retVal++;
            if (questions.Contains("U")) retVal++;
            if (questions.Contains("V")) retVal++;
            if (questions.Contains("W")) retVal++;
            if (questions.Contains("X")) retVal++;
            if (questions.Contains("Y")) retVal++;
            if (questions.Contains("Z")) retVal++;

            return retVal;
        }
    }
}
