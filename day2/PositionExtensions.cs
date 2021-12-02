namespace Aoc2021.Day2
{
    internal static class PositionExtensions
    {
        public static Position Add(this Position @this, Command cmd) 
        {
            var x = @this.X;
            var z = @this.Z;

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
