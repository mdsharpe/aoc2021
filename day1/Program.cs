using System.Linq;

namespace Aoc2021.Day1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var depths = System.IO.File.ReadAllLines(args[0])
                .Select(o => int.Parse(o))
                .ToArray();

            var increaseCount = 0;

            for (var i = 0; i < depths.Length; i++)
            {
                var increased = i > 0 && depths[i] > depths[i - 1];

                string desc;
                if (i > 0)
                {
                    desc = increased ? "increased" : "decreased";
                }
                else
                {
                    desc = "N/A - no previous measurement";
                }

                Console.WriteLine($"{depths[i]} ({desc})");

                if (increased)
                {
                    increaseCount++;
                }
            }

            Console.WriteLine("");
            Console.WriteLine($"{increaseCount} increases.");
        }
    }
}
