using System.Drawing;
using System.Numerics;

namespace AOC2021.Solutions;

public class Day5 : AdventBase
{
    private List<Line> lines;
    public Day5(string inputFile = "Day5.txt") : base(inputFile)
    {
        lines = this.InputLines.Select(x => new Line(x)).ToList();
    }

    protected override Task<string> ExecutePart1()
    {
        var straightLines = lines.Where(l => l.IsStraight).ToList();
        List<List<int>> lineCovers = InitializeBoard(straightLines);
        lineCovers = CoverPoints(lineCovers, straightLines);
        var intersections = lineCovers.Sum(l => l.Where(c => c >= 2).Count());
        return Task.FromResult($"intersections: {intersections}");
    }

    protected override Task<string> ExecutePart2()
    {
        List<List<int>> lineCovers = InitializeBoard(this.lines);
        lineCovers = CoverPoints(lineCovers, this.lines);
        var intersections = lineCovers.Sum(l => l.Where(c => c >= 2).Count());
        return Task.FromResult($"intersections: {intersections}");
    }

    private List<List<int>> InitializeBoard(List<Line> lines)
    {
        var maxX = lines.Max(l => l.Start.X < l.End.X ? l.End.X : l.Start.X) + 1;
        var maxY = lines.Max(l => l.Start.Y < l.End.Y ? l.End.Y : l.Start.Y) + 1;
        List<List<int>> board = new List<List<int>>();
        for (int i = 0; i < maxY; i++)
        {
            board.Add(new List<int>(new int[maxX]));
        }
        return board;
    }

    private List<List<int>> CoverPoints(List<List<int>> coverage, List<Line> lines)
    {
        foreach (var line in lines)
        {
            var location = new Point(line.Start.X, line.Start.Y);
            while (location != line.End)
            {
                coverage[location.Y][location.X] += 1;
                location = location.MoveTowards(line.End);
            }
            coverage[line.End.Y][line.End.X] += 1;
        }
        return coverage;
    }
}

internal class Line
{
    public Point Start { get; set; }
    
    public Point End { get; set; }

    public bool IsStraight
    {
        get { return IsHorizontal || IsVertical; }
    }

    public bool IsHorizontal
    {
        get { return Start.Y == End.Y; }
    }

    public bool IsVertical
    {
        get { return Start.X == End.X; }
    }

    public Line(string input)
    {
        var points = Regex.Matches(input, @"(\d+,\d+)+");
        var coords1 = points[0].Value.Split(',').Select(int.Parse).ToArray();
        var coords2 = points[1].Value.Split(',').Select(int.Parse).ToArray();
        Start = new Point(coords1[0], coords1[1]);
        End = new Point(coords2[0], coords2[1]);    
    }
}
