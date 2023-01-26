using NUnit.Framework;

namespace ControlTasks;

[TestFixture]
public class LeapYearChecker_should
{
    private readonly LeapYearChecker _leapYearChecker = new();
    
    [TestCase(3)]
    [TestCase(27)]
    [TestCase(393)]
    [TestCase(200)]
    public void NotLeapYear(int year)
    {
        Assert.False(_leapYearChecker.isLeapYear(year));
    }
    
    [TestCase(400)]
    [TestCase(4)]
    [TestCase(160)]
    [TestCase(444)]
    public void LeapYear(int year)
    {
        Assert.True(_leapYearChecker.isLeapYear(year));
    }
    
    
}