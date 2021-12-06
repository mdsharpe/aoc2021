using System;
using System.Linq;
using System.Text;

namespace Aoc2021.Day6
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var fishes = System.IO.File.ReadAllText(args[0])
                .Split(',')
                .Select(int.Parse)
                .Select(o => new Fish(o))
                .ToList();

            var runLength = int.Parse(args[1]);
            var verbose = args.Length > 2 && args.Contains("verbose", StringComparer.OrdinalIgnoreCase);

            if (verbose)
            {
                Print(fishes, 0);
            }

            for (var iteration = 1; iteration <= runLength; iteration++)
            {
                foreach (var fish in fishes.ToArray())
                {
                    if (fish.Iterate())
                    {
                        fishes.Add(new Fish());
                    }
                }

                if (verbose)
                {
                    Print(fishes, iteration);
                }
            }

            Console.WriteLine();
            Console.WriteLine($"After {runLength} days there are {fishes.Count} fishes.");
        }

        private static void Print(IEnumerable<Fish> fishes, int iteration)
        {
            var output = new StringBuilder();

            if (iteration < 1)
            {
                output.Append("Initial state:");
            }
            else
            {
                output.AppendFormat("After {0:00} days:", iteration);
            }

            output.Append('\t');

            output.Append(string.Join(',', fishes.Select(o => o.Timer)));

            Console.WriteLine(output.ToString());
        }
    }
}
