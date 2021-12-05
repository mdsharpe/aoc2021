using System.Text.RegularExpressions;

namespace Aoc2021.Day5
{
    internal class Line
    {
        private static readonly Regex ParseRegex = new Regex("^(\\d+),(\\d+) -> (\\d+),(\\d+)$");

        public Line(int fromX, int fromY, int toX, int toY)
            : this(new Point(fromX, fromY), new Point(toX, toY))
        {
        }

        public Line(Point from, Point to)
        {
            From = from;
            To = to;
        }

        public Point From { get; }
        public Point To { get; }

        public bool IsHorizontal => From.Y == To.Y;

        public bool IsVertical => From.X == To.X;
        public static Line Parse(string s)
        {
            var match = ParseRegex.Match(s);

            return new Line(
                int.Parse(match.Groups[1].Value),
                int.Parse(match.Groups[2].Value),
                int.Parse(match.Groups[3].Value),
                int.Parse(match.Groups[4].Value)
            );
        }

        public IEnumerable<Point> EnumeratePoints()
        {
            yield return From;

            var len = Math.Max(
                Math.Abs(To.X - From.X),
                Math.Abs(To.Y - From.Y)
            );

            for (var i = 1; i <= len; i++)
            {
                var p = (decimal)i / len;
                var x = From.X + ((To.X - From.X) * p);
                var y = From.Y + ((To.Y - From.Y) * p);
                yield return new Point(
                    (int)Math.Round(x, 0, MidpointRounding.AwayFromZero),
                    (int)Math.Round(y, 0, MidpointRounding.AwayFromZero));
            }
        }
    }
}
