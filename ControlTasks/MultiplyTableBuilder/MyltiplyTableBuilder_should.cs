using NUnit.Framework;

namespace ControlTasks;

[TestFixture]
public class MyltiplyTableBuilder_should
{
    private readonly MultiplyTableBuilder _tableBuilder = new ();

    [TestCase(1,2)]
    [TestCase(5,6)]
    public void CorrectValuesInTable(int row, int column)
    {
        var table = _tableBuilder.BuildTable();
        Assert.AreEqual(table[row,column], (row+1)*(column+1));
    }
    
}