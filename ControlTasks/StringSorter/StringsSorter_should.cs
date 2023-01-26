using NUnit.Framework;

namespace ControlTasks;

[TestFixture]
public class StringsSorter_should
{
    private readonly StringsSorter _sorter = new();
    [Test]
    public void Sort()
    {
        var list = new List<string>() {"b", "c", "d", "e"};
        list.Sort();
        var listForMySort = new List<string>() {"b", "c", "d", "e"};
        _sorter.MergeSort(listForMySort, 0, listForMySort.Count - 1);
        CollectionAssert.AreEqual(list, listForMySort);
    }

    [Test]
    public void EmptySort()
    {
        var list = new List<string>();
        _sorter.MergeSort(list, 0, list.Count-1);
        CollectionAssert.AreEqual(new List<string>(), list);
    }

    [Test]
    public void SortFromFile()
    {
        string workingDirectory = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(workingDirectory)?.Parent.Parent?.FullName;
        var sortedData = _sorter.Sort( projectDirectory + "\\data.txt");
        Assert.AreEqual(new List<string>(){ "a", "b", "c", "d", "e","f"}, sortedData.Result);
    }
}