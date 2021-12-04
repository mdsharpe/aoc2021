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

            var winningBoards = new Dictionary<Board, (int unmarkedSum, int lastDraw)>();

            for (var i = 1; i <= allDraws.Length; i++)
            {
                var draws = allDraws.Take(i).ToArray();

                var newWins = boards
                    .Where(o => !winningBoards.ContainsKey(o))
                    .Where(o => o.GetIsWin(draws))
                    .ToArray();

                foreach (var newWin in newWins)
                {
                    var unmarkedSum = newWin
                        .EnumerateAllNumbers()
                        .Except(draws)
                        .Sum();
                    winningBoards.Add(newWin, (unmarkedSum, draws.Last()));
                }
            }

            void writeBoard(Board board, int unmarkedSum, int lastDraw)
            {
                Console.WriteLine($"{unmarkedSum} * {lastDraw} = {unmarkedSum * lastDraw}");
            }

            var firstWin = winningBoards.First();
            Console.WriteLine("First winning board:");
            writeBoard(firstWin.Key, firstWin.Value.unmarkedSum, firstWin.Value.lastDraw);

            var lastWin = winningBoards.Last();
            Console.WriteLine("Last winning board:");
            writeBoard(lastWin.Key, lastWin.Value.unmarkedSum, lastWin.Value.lastDraw);
        }
    }
}
