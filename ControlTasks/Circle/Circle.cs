namespace ControlTasks;

public struct Point
{
    public double X { get; set; }
    public double Y { get; set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }
}
public class Circle
{
    public int Radius { get; }
    public Point Center { get; }

    public Circle(Point center, int radius)
    {
        Center = center;
        Radius = radius;
    }

    public bool ContainsPoint(Point point)
    {
        return Math.Pow(point.X - Center.X, 2) + Math.Pow(point.Y - Center.Y, 2) <= Radius * Radius;
    }
}