using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace _20201211_01
{
    class Program
    {
        private const char Empty = 'L';
        private const char Occupied = '#';
        private const char Floor = '.';

        private static readonly (int y, int x)[] Kernel = {(-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1)};

        static void Main(string[] args)
        {
            var parsedInput = System.IO.File.ReadAllLines(@"PuzzleInput.txt");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Payload here
            Console.WriteLine(Solve(parsedInput, 4, CountPart1));

            sw.Stop();
            Console.WriteLine(String.Format("Elapsed time: {0} ms.", sw.ElapsedMilliseconds.ToString()));
            Console.ReadLine();
        }

        private static int Solve(string[] curr, int threshold, Func<string[], (int, int), int> countAdjacent)
        {
            bool mutated;
            string[] prev;
            do
            {
                prev = curr;
                curr = Step(curr, threshold, countAdjacent);
            } while (!prev.SequenceEqual(curr));

            return curr.SelectMany(r => r).Count(c => c == Occupied);
        }

        private static string[] Step(string[] grid, int threshold, Func<string[], (int, int), int> count)
        {
            var nextGrid = new string[grid.Length];
            for (var r = 0; r< grid.Length; r++)
            {
                var sb = new StringBuilder();
                for (var c = 0; c< grid[r].Length; c++)
                {
                    var adjacent = count(grid, (r, c));
                    switch (grid[r][c])
                    {
                        case Empty when adjacent == 0:
                            sb.Append(Occupied);
                            break;
                        case Occupied when adjacent >= threshold:
                            sb.Append(Empty);
                            break;
                        default:
                            sb.Append(grid[r][c]);
                            break;
                    }
                }

                nextGrid[r] = sb.ToString();
            }

            return nextGrid;
        }

        private static int CountPart1(string[] map, (int, int) coords)
        {
            return Kernel
                .Select(d => d.Add(coords))
                .Count(p => map.Get(p) == Occupied);
        }
    }
}
