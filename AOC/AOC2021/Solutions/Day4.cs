using System;

namespace AOC2021.Solutions;

public class Day4 : AdventBase
{
    private int[] draw;
    private List<BingoBoard> boards = new List<BingoBoard>();

    public Day4() : base("Day4.txt")
    {
        this.draw = this.InputLines[0].Split(',').Select(s => Convert.ToInt32(s)).ToArray();
        this.InputLines.RemoveRange(0, 2);
        var boardSize = this.InputLines.FindIndex(s => string.IsNullOrWhiteSpace(s)) + 1;
        var boards = this.InputLines.Chunk(boardSize).ToList();
        boards.ForEach(b => this.boards.Add(new BingoBoard(b)));
    }

    protected override Task<string> ExecutePart1()
    {
        for (int i = 0; i < draw.Length; i++)
        {
            MarkDraw(draw[i]);
            var winningBoard = this.boards.FirstOrDefault(b => b.HasWon);
            if (winningBoard != null)
            {
                var unmarkedSum = winningBoard.GetUnmarkedSum();
                return Task.FromResult($"Board with unmarked sum: {unmarkedSum} on draw: {draw[i]} won with final score: {unmarkedSum * draw[i]}");
            }
        }

        return Task.FromResult("Ya fucked up, nobody won");
    }

    protected override Task<string> ExecutePart2()
    {
        for (int i = 0; i < draw.Length; i++)
        {
            MarkDraw(draw[i]);
            var winningBoard = this.boards.FirstOrDefault(b => b.HasWon);
            if (winningBoard != null && this.boards.Count() == 1)
            {
                var unmarkedSum = winningBoard.GetUnmarkedSum();
                return Task.FromResult($"Board with unmarked sum: {unmarkedSum} on draw: {draw[i]} last won with final score: {unmarkedSum * draw[i]}");
            }
            this.boards = this.boards.Where(b => !b.HasWon).ToList();
        }

        return Task.FromResult("Ya fucked up, nobody won");
    }


    private void MarkDraw(int draw)
    {
        foreach (var board in this.boards)
        {
            board.Mark(draw);
        }
    }
}

public class BingoBoard
{
    public bool HasWon = false;
    private List<BingoNumber> board;
    private int xSize = 0;
    private int ySize = 0;

    public BingoBoard(string[] boardStrings)
    {
        boardStrings = boardStrings.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
        this.board = new List<BingoNumber>();
        ySize = boardStrings.Length;

        for (int y = 0; y < boardStrings.Length; y++)
        {
            var numbers = Regex.Matches(boardStrings[y], @"\d+").Select(m => Convert.ToInt32(m.Value)).ToArray();
            if (xSize == 0)
                xSize = numbers.Length;
            for (int x = 0; x < numbers.Length; x++)
            {
                board.Add(new BingoNumber(x, y, numbers[x]));
            }
        }
    }

    /// <summary>
    /// Mark a number and return true if bingo
    /// </summary>
    public bool Mark(int number)
    {
        if (board.Any(n => n.Number == number))
        {
            board.ForEach(n =>
            {
                if (n.Number == number)
                {
                    n.Marked = true;
                }
            });
            return IsBingo();
        }

        return false;
    }

    public int GetUnmarkedSum()
    {
        return board.Where(b => !b.Marked).Sum(b => b.Number);
    }

    private bool IsBingo()
    {
        for (int x = 0; x < xSize; x++)
        {
            if (board.Where(n => n.X == x).All(n => n.Marked))
            {
                this.HasWon = true;
                return this.HasWon;
            }
        }

        for (int y = 0; y < ySize; y++)
        {
            if (board.Where(n => n.Y == y).All(n => n.Marked))
            {
                this.HasWon = true;
                return this.HasWon;
            }
        }

        return this.HasWon;
    }
}

public record BingoNumber(int X, int Y, int Number)
{
    public bool Marked { get; set; } = false;
};

