using System.Drawing;

namespace AOC2021.Solutions;

public static class PointExtensions
{
    public static Point MoveTowards(this Point location, Point target)
    {
        if (location.X == target.X && location.Y == target.Y)
            return location;
        var newX = location.X;
        if (location.X != target.X)
        {
            newX = location.X < target.X ? location.X + 1 : location.X - 1;
        }
        var newY = location.Y;
        if (location.Y != target.Y)
        {
            newY = location.Y < target.Y ? location.Y + 1 : location.Y - 1;
        }
        return new Point(newX, newY);
    }

    public static List<Point> PointsBetween(this Point location, Point target)
    {
        var points = new List<Point> { location };
        
        var dX = location.X == target.X ? 0 : location.X < target.X ? 1 : -1;
        var dY = location.Y == target.Y ? 0 : location.Y < target.Y ? 1 : -1;

        while (points.Last() != target)
        {
            points.Add(new Point(points.Last().X + dX, points.Last().Y + dY));
        }

        return points;
    }
}