using System;
using System.Linq;
using System.Collections.Immutable;

namespace Aoc2021.Day8
{
    internal class Entry
    {
        public Entry(string[] signalPatterns, string[] digitStrings)
        {
            SignalPatterns = signalPatterns.ToImmutableArray();
            DigitStrings = digitStrings.ToImmutableArray();
        }

        public IImmutableList<string> SignalPatterns { get; }
        public IImmutableList<string> DigitStrings { get; }

        public static Entry Parse(string text)
        {
            var patterns = text.Split('|')
                .Select(o => o.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                .ToArray();

            return new Entry(
                patterns[0],
                patterns[1]);
        }

        public int?[] GetDigits() => DigitStrings.Select(o => GetDigit(o)).ToArray();

        private int? GetDigit(string text)
        {
            switch (text.Length)
            {
                case 3:
                    return 7;

                case 2:
                    return 1;

                case 4:
                    return 4;

                case 6:
                    return 8;

                default:
                    break;
            }

            return null;
        }
    }
}
