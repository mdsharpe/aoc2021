using System.Collections;
using System.Linq;

namespace Aoc2021.Day3
{
    internal static class BitArrayExtensions
    {
        public static int ToInt32(this BitArray @this)
        {
            var intArray = new int[1];
            new BitArray(@this.Cast<bool>().Reverse().ToArray())
                .CopyTo(intArray, 0);
            return intArray[0];
        }

        public static bool? GetMostCommon(this IList<BitArray> list, int index)
        {
            var half = list.Count / 2m;
            var trueCount = list.Count(o => o[index]);

            if (trueCount > half)
            {
                return true;
            }
            else if (trueCount < half)
            {
                return false;
            }
            else
            {
                return null;
            }
        }

        public static string ToBinaryString(this BitArray @this)
        {
            return new string(
                @this
                    .Cast<Boolean>()
                    .Select(o => o ? '1' : '0')
                    .ToArray());
        }
    }
}
