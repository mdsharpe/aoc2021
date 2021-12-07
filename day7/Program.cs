using System.Linq;

namespace Aoc2021.Day7
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var crabLocations = System.IO.File.ReadAllText(args[0])
                .Split(',')
                .Select(int.Parse)
                .ToArray();

            var constantRate = args.Length > 1 && args.Any(o => string.Equals("cr", o, StringComparison.OrdinalIgnoreCase));

            var x = from i in Enumerable.Range(crabLocations.Min(), crabLocations.Max() - crabLocations.Min())
                    select new
                    {
                        Location = i,
                        Fuel = CalculateFuel(crabLocations, i, constantRate)
                    };

            var bestLocation = x.OrderBy(o => o.Fuel).First();

            Console.WriteLine($"Location {bestLocation.Location} costs a total of {bestLocation.Fuel} fuel.");
        }

        private static int CalculateFuel(int[] crabLocations, int targetLocation, bool constantRate)
        {
            int fuel;

            if (constantRate)
            {
                fuel = crabLocations.Select(o => Math.Abs(o - targetLocation)).Sum();
            }
            else
            {
                fuel = crabLocations.Select(o => Enumerable.Range(0, Math.Abs(o - targetLocation) + 1).Sum()).Sum();
            }

            return fuel;
        }
    }
}
