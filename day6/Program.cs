using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aoc2021.Day6
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var initialCounts = System.IO.File.ReadAllText(args[0])
                .Split(',')
                .Select(int.Parse)
                .GroupBy(o => o)
                .ToDictionary(o => o.Key, o => o.LongCount());

            var fishes = Enumerable.Range(0, 9)
                .Select(i => initialCounts.GetValueOrDefault(i))
                .ToArray();

            var runLength = int.Parse(args[1]);
            var verbose = args.Length > 2 && args.Contains("verbose", StringComparer.OrdinalIgnoreCase);

            if (verbose)
            {
                Print(fishes);
            }

            for (var iteration = 1; iteration <= runLength; iteration++)
            {
                long prev = 0;

                for (var i = 8; i >= 0; i--)
                {
                    var tmp = fishes[i];
                    fishes[i] = prev;
                    prev = tmp;
                }

                fishes[6] += prev;
                fishes[8] = prev;

                if (verbose)
                {
                    Print(fishes);
                }
            }

            Console.WriteLine();
            Console.WriteLine($"After {runLength} days there are {fishes.Sum()} fish.");
        }

        private static void Print(long[] fishes)
        {
            Console.WriteLine(string.Join(',', fishes.Select(o => o.ToString()).Reverse()));
        }
    }
}
