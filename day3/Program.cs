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
            var oxygenPossibleValues = bitArrays.ToList();
            var scrubberPossibleValues = bitArrays.ToList();
            
            for (var i = 0; i < digitCount; i++)
            {
                var mostCommon = bitArrays.GetMostCommon(i).Value;
                gammaBitArray[i] = mostCommon;
                epsilonBitArray[i] = !mostCommon;

                if (oxygenPossibleValues.Count > 1)
                {
                    var oxMostCommon = oxygenPossibleValues.GetMostCommon(i) ?? true;
                    oxygenPossibleValues = oxygenPossibleValues.Where(o => o[i] == oxMostCommon).ToList();
                }

                if (scrubberPossibleValues.Count > 1)
                {
                    var scMostCommon = scrubberPossibleValues.GetMostCommon(i);
                    var scLeastCommon = scMostCommon.HasValue ? !scMostCommon.Value : false;
                    scrubberPossibleValues = scrubberPossibleValues.Where(o => o[i] == scLeastCommon).ToList();
                }
            }

            var gammaRate = gammaBitArray.ToInt32();
            var epsilonRate = epsilonBitArray.ToInt32();
            Console.WriteLine($"Gamma rate: {gammaBitArray.ToBinaryString()} = {gammaRate}");
            Console.WriteLine($"Epsilon rate: {epsilonBitArray.ToBinaryString()} = {epsilonRate}");
            Console.WriteLine($"Power consumption: {gammaRate * epsilonRate}");

            var oxygenBitArray = oxygenPossibleValues.Single();
            var scrubberBitArray = scrubberPossibleValues.Single();
            var oxygenRating = oxygenBitArray.ToInt32();
            var scrubberRating = scrubberBitArray.ToInt32();
            Console.WriteLine($"Oxygen generator rating: {oxygenBitArray.ToBinaryString()} = {oxygenRating}");
            Console.WriteLine($"CO2 scrubber rating: {scrubberBitArray.ToBinaryString()} = {scrubberRating}");
            Console.WriteLine($"Life support rating: {oxygenRating * scrubberRating}");
        }
    }
}
