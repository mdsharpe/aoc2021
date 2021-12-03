using System.Collections;
using System.Linq;

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

        public static string ToBinaryString(this BitArray @this)
        {
            return new string(
                @this
                    .Cast<Boolean>()
                    .Select(o => o ? '1' : '0')
                    .Reverse()
                    .ToArray());
        }
    }
}
