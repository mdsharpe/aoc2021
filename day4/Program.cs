using System.Linq;

namespace Aoc2021.Day4
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var inputLines = System.IO.File.ReadAllLines(args[0]);

            var allDraws = inputLines.First().Split(',').Select(int.Parse).ToArray();

            var boardLineBuffer = new List<string>();
            var boards = new List<Board>();

            foreach (var line in inputLines.Skip(1))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    boardLineBuffer.Add(line);
                }
                else
                {
                    if (boardLineBuffer.Any())
                    {
                        boards.Add(Board.Parse(boardLineBuffer));
                        boardLineBuffer.Clear();
                    }
                }
            }

            if (boardLineBuffer.Any())
            {
                boards.Add(Board.Parse(boardLineBuffer));
            }

            Board? winningBoard = null;
            var draws = Array.Empty<int>();

            for (var i = 1; i <= allDraws.Length; i++)
            {
                draws = allDraws.Take(i).ToArray();

                winningBoard = boards.FirstOrDefault(o => o.GetIsWin(draws));

                if (winningBoard != null)
                {
                    break;
                }
            }

            if (winningBoard != null)
            {
                var unmarkedSum = winningBoard
                    .EnumerateAllNumbers()
                    .Except(draws)
                    .Sum();

                var lastDraw = draws.Last();

                Console.WriteLine($"{unmarkedSum} * {lastDraw} = {unmarkedSum * lastDraw}");
            }
        }
    }
}
