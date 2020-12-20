using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace _20201220_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = System.IO.File.ReadAllText(@"PuzzleInput.txt");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Payload here
            var tiles = RestoreTiles(input);

            long result = (long)tiles[0, 0].id * tiles[11, 11].id * tiles[0, 11].id * tiles[11, 0].id;

            sw.Stop();
            Console.WriteLine(String.Format("The answer is: {0}.", result));
            Console.WriteLine(String.Format("Elapsed time: {0} ms.", sw.ElapsedMilliseconds.ToString()));
            Console.ReadLine();
        }

        private static Tile[] Parse(string input)
        {
            return (
                from block in input.Split("\r\n\r\n")
                let lines = block.Split("\r\n")
                select new Tile(int.Parse(lines[0].Trim(':').Split(" ")[1]), lines.Skip(1).Where(x => x != "").ToArray())
            ).ToArray();
        }

        private static Tile[,] RestoreTiles(string input)
        {
            var tiles = Parse(input).ToList();

            Tile findTile(string topPattern, string leftPattern)
            {
                foreach (var tile in tiles)
                {

                    for (var i = 0; i < 8; i++)
                    {
                        var topMatch = topPattern != null ? tile.top() == topPattern :
                            !tiles.Any(tileB => tileB.id != tile.id && tileB.edges.Contains(tile.top()));
                        var leftMatch = leftPattern != null ? tile.left() == leftPattern :
                            !tiles.Any(tileB => tileB.id != tile.id && tileB.edges.Contains(tile.left()));

                        if (topMatch && leftMatch)
                        {
                            return tile;
                        }
                        tile.ChangePosition();
                    }
                }
                throw new Exception();
            }

            var mtx = new Tile[12, 12];
            for (var irow = 0; irow < 12; irow++)
            {
                for (var icol = 0; icol < 12; icol++)
                {
                    var topPattern = irow == 0 ? null : mtx[irow - 1, icol].bottom();
                    var leftPattern = icol == 0 ? null : mtx[irow, icol - 1].right();

                    var tile = findTile(topPattern, leftPattern);
                    mtx[irow, icol] = tile;
                    tiles.Remove(tile);
                }
            }

            return mtx;
        }
    }

    class Tile
    {
        public int id;
        string[] image;
        public int size;
        // int orientation = 0;
        // int flip = 0;

        int position = 0;

        public string[] edges;

        public Tile(int title, string[] image)
        {
            this.id = title;
            this.image = image;
            this.size = image.Length;

            if (image.Length == 11)
            {
                Console.WriteLine("x");
            }
            this.edges = new[] {
                edge(0,0,0,1),
                edge(0,0,1,0),
                edge(size-1,0,0,1),
                edge(size-1,0,-1,0),
                edge(0,size-1,0,-1),
                edge(0,size-1,1,0),
                edge(size-1,size-1,0,-1),
                edge(size-1,size-1,-1,0),
            };
        }

        public void ChangePosition()
        {
            this.position++;
            this.position %= 8;
        }

        // public void Rotate() {
        //     this.orientation++;
        //     this.orientation %= 4;
        // }

        // public void Flip() {
        //     this.flip++;
        //     this.orientation %= 2;
        // }

        public char this[int irow, int icol]
        {
            get
            {


                for (var i = 0; i < position % 4; i++)
                {
                    (irow, icol) = (icol, size - 1 - irow);
                }

                if (position % 8 >= 4)
                {
                    icol = size - 1 - icol;
                }

                return this.image[irow][icol];
            }
        }

        string edge(int irow, int icol, int drow, int dcol)
        {
            var st = "";
            for (var i = 0; i < size; i++)
            {
                st += this[irow, icol];
                irow += drow;
                icol += dcol;
            }
            return st;
        }

        public string row(int irow) => edge(irow, 0, 0, 1);
        public string top() => edge(0, 0, 0, 1);
        public string bottom() => edge(size - 1, 0, 0, 1);
        public string left() => edge(0, 0, 1, 0);
        public string right() => edge(0, size - 1, 1, 0);
    }
}
