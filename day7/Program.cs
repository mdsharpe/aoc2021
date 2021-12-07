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

            var x = from i in Enumerable.Range(crabLocations.Min(), crabLocations.Max() - crabLocations.Min())
                    select new
                    {
                        Location = i,
                        Fuel = crabLocations.Select(o => Math.Abs(o - i)).Sum()
                    };

            var bestLocation = x.OrderBy(o => o.Fuel).First();

            Console.WriteLine($"Location {bestLocation.Location} costs a total of {bestLocation.Fuel} fuel.");
        }
    }
}
