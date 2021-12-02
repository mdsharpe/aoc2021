using System;

namespace Aoc2021.Day2
{
    internal class Command
    {
        public Command(Direction direction, int units)
        {
            Direction = direction;
            Units = units;
        }

        public Direction Direction { get; }
        public int Units { get; }

        public static Command Parse(string s)
        {
            var parts = s.Split(' ');

            return new Command(
                (Direction)Enum.Parse(typeof(Direction), parts[0], ignoreCase: true),
                int.Parse(parts[1]));
        }
    }
}
