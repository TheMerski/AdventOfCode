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
        Dictionary<Point, int> points = new Dictionary<Point, int>();
        points = CoverPoints(points, straightLines);
        var intersections = points.Count(p => p.Value > 1);
        return Task.FromResult($"intersections: {intersections}");
    }

    protected override Task<string> ExecutePart2()
    {
        Dictionary<Point, int> points = new Dictionary<Point, int>();
        points = CoverPoints(points, this.lines);
        var intersections = points.Count(p => p.Value > 1);
        return Task.FromResult($"intersections: {intersections}");
    }

    private Dictionary<Point, int> CoverPoints(Dictionary<Point, int> coverage, List<Line> lines)
    {
        foreach (var line in lines)
        {
            foreach(var point in line.Points)
            {
                coverage[point] = coverage.ContainsKey(point) ? coverage[point] + 1 : 1;
            }
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

    public List<Point> Points
    {
        get { return Start.PointsBetween(End); }
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
