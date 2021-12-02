namespace Aoc2021.Day2
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var position = new Position(0, 0);

            var commands = System.IO.File.ReadAllLines(args[0])
                .Select(o => Command.Parse(o));

            foreach (var cmd in commands)
            {
                position = position.Add(cmd);
            }

            Console.WriteLine(position.X * position.Z);
        }
    }
}
