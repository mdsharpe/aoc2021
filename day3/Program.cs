using System.Collections;
using System.Linq;

namespace Aoc2021.Day3
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var bitArrays = System.IO.File.ReadAllLines(args[0])
                .Select(o => o.Select(c => c != '0').ToArray())
                .Select(o => new BitArray(o))
                .ToArray();
            var inputLength = bitArrays.Length;
            var digitCount = bitArrays.First().Length;

            if (bitArrays.Any(o => o.Length != digitCount))
            {
                throw new InvalidOperationException("All input bit strings must be the same length.");
            }

            var gammaBitArray = new BitArray(digitCount);
            var epsilonBitArray = new BitArray(digitCount);

            var threshold = Math.Floor(inputLength / 2m);
            for (var i = 0; i < digitCount; i++)
            {
                var x = bitArrays.Count(o => o[i]) >= threshold;
                gammaBitArray[i] = x;
                epsilonBitArray[i] = !x;
            }

            var gammaRate = gammaBitArray.ToInt32();
            var epsilonRate = epsilonBitArray.ToInt32();

            Console.WriteLine($"Gamma rate: {gammaRate}");
            Console.WriteLine($"Epsilon rate: {epsilonRate}");
            Console.WriteLine($"Power consumption: {gammaRate * epsilonRate}");
        }
    }
}
