using System.Linq;

namespace Aoc2021.Day1
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var depths = System.IO.File.ReadAllLines(args[0])
                .Select(o => int.Parse(o))
                .ToArray();

            var windowSize = int.Parse(args[1]);

            var increaseCount = 0;

            for (var i = 0; i < depths.Length; i++)
            {
                var thisWindow = GetWindowSum(depths, i, windowSize);

                if (thisWindow.HasValue)
                {
                    string desc;

                    var previousWindow = GetWindowSum(depths, i - 1, windowSize);
                    if (previousWindow.HasValue)
                    {
                        var increased = thisWindow.Value > previousWindow.Value;

                        if (increased)
                        {
                            increaseCount++;
                        }

                        desc = increased ? "increased" : "decreased";
                    }
                    else
                    {
                        desc = "N/A - no previous measurement";
                    }

                    Console.WriteLine($"{thisWindow.Value} ({desc})");
                }
            }

            Console.WriteLine("");
            Console.WriteLine($"{increaseCount} increases.");
        }

        private static int? GetWindowSum(int[] values, int i, int size)
        {
            var skip = i - (size - 1);

            if (skip < 0)
            {
                return null;
            }

            return values.Skip(skip).Take(size).Sum();
        }
    }
}
