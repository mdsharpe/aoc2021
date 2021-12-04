namespace Aoc2021.Day4
{
    internal class Board
    {
        private readonly int[][] _nums;

        private Board(int[][] nums)
        {
            if (!nums.Any())
            {
                throw new ArgumentException();
            }

            var height = nums.Length;
            var width = nums.First().Length;

            if (nums.Any(o => o.Length != width))
            {
                throw new ArgumentException();
            }

            this._nums = nums;
        }

        public static Board Parse(List<string> lines)
        {
            var nums = lines
                .Select(o => o.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray())
                .ToArray();
            return new Board(nums);
        }

        public IEnumerable<int> EnumerateAllNumbers()
        {
            return this._nums
                .AsEnumerable()
                .Select(o => o.AsEnumerable())
                .Aggregate(Enumerable.Concat);
        }

        public bool GetIsWin(int[] draws)
        {
            var rowsAndCols = Enumerable.Concat(
                _nums,
                EnumerateCols()
            );

            return rowsAndCols.Any(o => o.All(draws.Contains));
        }

        private IEnumerable<IEnumerable<int>> EnumerateCols()
        {
            var width = this._nums.First().Length;

            for (var i = 0; i < width; i++)
            {
                yield return _nums.Select(o => o[i]);
            }
        }
    }
}
