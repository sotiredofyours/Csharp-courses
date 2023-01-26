namespace ControlTasks;

public struct Point
{
    public int X { get; set; }
    public int Y { get; set; }
}
public class Circle
{
    public int Radius { get; }
    public Point Center { get; }
    Circle(Point center, int radius)
    {
        Center = center;
        Radius = radius;
    }

    public bool ContainsPoint(Point point)
    {
        return Math.Pow(point.X - Center.X, 2) + Math.Pow(point.Y - Center.Y, 2) <= Radius;
    }
}