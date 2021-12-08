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

            for (var i = 1; i <= 8; i++)
            {
                Console.WriteLine($"Digit {i} appears {digits.Count(o => o == i)} times.");
            }
        }
    }
}
