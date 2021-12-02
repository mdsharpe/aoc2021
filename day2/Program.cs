namespace Aoc2021.Day2
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var commands = System.IO.File.ReadAllLines(args[0])
                .Select(o => Command.Parse(o));

            Position position;

            if (args.Length > 1 && string.Equals(args[1], "aimed", StringComparison.OrdinalIgnoreCase))
            {
                position = new AimedPosition(0, 0, 0);
            }
            else
            {
                position = new Position(0, 0);
            }

            foreach (var cmd in commands)
            {
                position = position.Add(cmd);
            }

            Console.WriteLine(position.X * position.Z);
        }
    }
}
