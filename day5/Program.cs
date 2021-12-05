namespace Aoc2021.Day5
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines(args[0])
                .Select(o => Line.Parse(o))
                .ToArray();

            if (args.Skip(1).Any(o => string.Equals(o, "hvonly", StringComparison.OrdinalIgnoreCase)))
            {
                lines = lines
                   .Where(o => o.IsHorizontal || o.IsVertical)
                   .ToArray();
            }

            var pointCounts = lines
                .SelectMany(o => o.EnumeratePoints())
                .GroupBy(o => o)
                .ToDictionary(o => o.Key, o => o.Count());

            if (args.Skip(1).Any(o => string.Equals(o, "showmap", StringComparison.OrdinalIgnoreCase)))
            {
                WriteMap(pointCounts);
                Console.WriteLine();
            }

            var intersectionCount = pointCounts
                .Where(o => o.Value > 1)
                .Count();

            Console.WriteLine($"{intersectionCount} intersections.");
        }

        private static void WriteMap(Dictionary<Point, int> pointCounts)
        {
            var height = pointCounts.Select(o => o.Key.Y).Max();
            var width = pointCounts.Select(o => o.Key.X).Max();

            for (var y = 0; y <= height; y++)
            {
                for (var x = 0; x <= width; x++)
                {
                    if (!pointCounts.TryGetValue(new Point(x, y), out int count))
                    {
                        count = 0;
                    }

                    Console.Write(count);
                }

                Console.WriteLine();
            }
        }
    }
}
