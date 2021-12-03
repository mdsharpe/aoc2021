using System.Collections;

namespace Aoc2021.Day3
{
    internal static class BitArrayExtensions
    {
        public static int ToInt32(this BitArray @this)
        {
            var intArray = new int[1];
            @this.CopyTo(intArray, 0);
            return intArray[0];
        }
    }
}
