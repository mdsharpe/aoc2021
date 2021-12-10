using System.Linq;

namespace Aoc2021.Day8
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var entries = System.IO.File.ReadAllLines(args[0])
                .Select(o => Entry.Parse(o))
                .ToArray();

            var digits = entries
                .SelectMany(o => o.GetDigits())
                .Where(o => o != null)
                .ToArray();

            var total = 0;

            for (var i = 1; i <= 8; i++)
            {
                var count = digits.Count(o => o == i);
                total += count;
                Console.WriteLine($"Digit {i} appears {count} times.");
            }

            Console.WriteLine($"Detected a total of {total} digits.");
        }
    }
}
