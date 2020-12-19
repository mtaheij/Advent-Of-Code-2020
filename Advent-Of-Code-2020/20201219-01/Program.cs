using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace _20201219_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string allInput = System.IO.File.ReadAllText(@"PuzzleInput.txt");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Payload here
            int result = Part1(allInput);

            sw.Stop();
            Console.WriteLine(String.Format("Result: {0}.", result));
            Console.WriteLine(String.Format("Elapsed time: {0} ms.", sw.ElapsedMilliseconds.ToString()));
            Console.ReadLine();
        }

        static int Part1(string input) => Run(ParseInput(input));

        static int Run(Input input)
        {
            var rules = input.Rules.ToList();
            var matcher = new Matcher(rules);
            int count = 0;
            foreach (var msg in input.Messages)
            {
                if (matcher.IsMach(msg))
                {
                    count++;
                }
            }
            return count;
        }

        class Matcher
        {
            private ILookup<int, Rule> _rules;

            public Matcher(IEnumerable<Rule> rules)
            {
                _rules = rules.ToLookup(r => r.Num);
            }

            public bool IsMach(string input)
            {
                foreach (var end in Match(input, 0, 0))
                {
                    if (end == input.Length) return true;
                }
                return false;
            }

            IEnumerable<int> Match(string input, int num, int pos)
            {
                foreach (var rule in _rules[num])
                {
                    if (rule is LitRule lit)
                    {
                        foreach (var end in MatchLit(input, lit, pos))
                        {
                            yield return end;
                        }
                    }
                    else if (rule is SeqRule seq)
                    {
                        foreach (var end in MatchSeq(input, seq, pos, 0))
                        {
                            yield return end;
                        }
                    }
                    else
                    {
                        throw new ArgumentException(nameof(rule));
                    }
                }
            }

            IEnumerable<int> MatchLit(string input, LitRule lit, int pos)
            {
                if (string.CompareOrdinal(input, pos, lit.Lit, 0, lit.Lit.Length) == 0)
                {
                    yield return pos + lit.Lit.Length;
                }
            }

            IEnumerable<int> MatchSeq(string input, SeqRule seq, int pos, int index)
            {
                if (index == seq.Seq.Count)
                {
                    yield return pos;
                    yield break;
                }
                foreach (var end in Match(input, seq.Seq[index], pos))
                {
                    foreach (var end2 in MatchSeq(input, seq, end, index + 1))
                    {
                        yield return end2;
                    }
                }
            }
        }

        static Input ParseInput(string input)
        {
            var result = new Input();
            var lines = input.Trim().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var pat = new Regex(@"^(\d+):(?: ""([^""]*)""|(?: ((?:\| )?)(\d+))+)\s*$");
            foreach (var line in lines)
            {
                if (pat.Match(line) is { Success: true } m)
                {
                    if (m.Groups[2].Success)
                    {
                        result.Rules.Add(new LitRule
                        {
                            Num = int.Parse(m.Groups[1].Value),
                            Lit = m.Groups[2].Value
                        });
                    }
                    else
                    {
                        var seq = new List<int>();
                        var alt = new List<List<int>> { seq };
                        for (int i = 0; i < m.Groups[4].Captures.Count; i++)
                        {
                            if (m.Groups[3].Captures[i].Length != 0)
                            {
                                alt.Add(seq = new List<int>());
                            }
                            seq.Add(int.Parse(m.Groups[4].Captures[i].Value));
                        }
                        foreach (var seql in alt)
                        {
                            result.Rules.Add(new SeqRule
                            {
                                Num = int.Parse(m.Groups[1].Value),
                                Seq = seql
                            });
                        }
                    }
                }
                else
                {
                    result.Messages.Add(line);
                }
            }
            return result;
        }

        abstract class Rule
        {
            public int Num { get; set; }
        }
        class LitRule : Rule
        {
            public string Lit { get; set; }
        }
        class SeqRule : Rule
        {
            public List<int> Seq { get; set; }
        }
        class Input
        {
            public List<Rule> Rules { get; } = new List<Rule>();
            public List<string> Messages { get; } = new List<string>();
        }
    }
}
