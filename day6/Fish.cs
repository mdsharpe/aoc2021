using System.Linq;

namespace Aoc2021.Day6
{
    internal class Fish
    {
        public Fish() : this(8)
        {

        }

        public Fish(int timer)
        {
            Timer = timer;
        }

        public int Timer { get; set; }

        public bool Iterate()
        {
            if (Timer == 0)
            {
                Timer = 6;
                return true;
            }

            Timer--;
            return false;
        }
    }
}
