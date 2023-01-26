using NUnit.Framework;

namespace ControlTasks;

[TestFixture]
public class Circle_should
{
    private readonly Point _center = new Point{ X = 0, Y = -1};
    private readonly int _radius = 2;
    
    [Test]
    public void CenterPoint()
    {
        var circle = new Circle(_center, _radius);
        Assert.True(circle.ContainsPoint(new Point(0, -1)));
    }
    
    [TestCase(0, 0)]
    [TestCase(-1, -1)]
    [TestCase(1.5d, 0)]
    [TestCase(0, -1.5)]
    [TestCase(0.2d, 0.2d)]
    public void PointsInCircle(double x, double y)
    {
        var circle = new Circle(_center, _radius);
        Assert.True(circle.ContainsPoint(new Point(x,y)));
    }
    
    [TestCase(0, -3)]
    [TestCase(0, 1)]
    [TestCase(2, -1)]
    [TestCase(-2, -1)]
    public void PointsOnEdgeOfCircle(double x, double y)
    {
        var circle = new Circle(_center, _radius);
        Assert.True(circle.ContainsPoint(new Point(x,y)));
    }

    [TestCase(-6, 0.2d)]
    [TestCase(10, 10)]
    [TestCase(-10, -10)]
    [TestCase(2.1d, 0)]
    public void PointsOutOfCircle(double x, double y)
    {
        var circle = new Circle(_center, _radius);
        Assert.False(circle.ContainsPoint(new Point(x,y)));
    }
}