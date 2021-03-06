namespace Aoc2021.Day2
{
    internal class Position
    {
        public Position(int x, int z)
        {
            X = x;
            Z = z;
        }

        public int X { get; }
        public int Z { get; }

        public virtual Position Add(Command cmd) 
        {
            var x = this.X;
            var z = this.Z;

            switch (cmd.Direction) 
            {
                case Direction.Forward:
                    x += cmd.Units;
                    break;

                case Direction.Up:
                    z -= cmd.Units;
                    break;

                case Direction.Down:
                    z += cmd.Units;
                    break;

                default:
                    throw new NotSupportedException();
            }

            return new Position(x, z);
        }
    }
}
