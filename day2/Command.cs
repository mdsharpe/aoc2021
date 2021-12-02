using System;

namespace Aoc2021.Day2
{
    internal class Command
    {
        public Direction Direction { get; set; }
        public int Units { get; set; }

        public static Command Parse(string s)
        {
            var parts = s.Split(' ');

            return new Command
            {
                Direction = (Direction)Enum.Parse(typeof(Direction), parts[0], ignoreCase: true),
                Units = int.Parse(parts[1])
            };
        }
    }
}
