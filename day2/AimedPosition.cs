namespace Aoc2021.Day2
{
    internal class AimedPosition : Position
    {
        public AimedPosition(int x, int z, int aim)
            : base(x, z)
        {
            Aim = aim;
        }

        public int Aim { get; }

        public override Position Add(Command cmd) 
        {
            var x = this.X;
            var z = this.Z;
            var aim = this.Aim;

            switch (cmd.Direction) 
            {
                case Direction.Forward:
                    x += cmd.Units;
                    z += aim * cmd.Units;
                    break;

                case Direction.Up:
                    aim -= cmd.Units;
                    break;

                case Direction.Down:
                    aim += cmd.Units;
                    break;

                default:
                    throw new NotSupportedException();
            }

            return new AimedPosition(x, z, aim);
        }
    }
}
