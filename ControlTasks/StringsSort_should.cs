using NUnit.Framework;

namespace ControlTasks;

[TestFixture]
public class StringsSort_should
{
    [Test]
    public void Sort()
    {
        var list = new List<string>() {"b", "c", "d", "e"};
        list.Sort();
        var listForMySort = new List<string>() {"b", "c", "d", "e"};
        StringsSort.MergeSort(listForMySort, 0, listForMySort.Count - 1);
        CollectionAssert.AreEqual(list, listForMySort);
    }

    [Test]
    public void EmptySort()
    {
        var list = new List<string>();
        StringsSort.MergeSort(list, 0, list.Count-1);
        CollectionAssert.AreEqual(new List<string>(), list);
    }

    [Test]
    public void SortFromFile()
    {
        string workingDirectory = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(workingDirectory)?.Parent.Parent?.FullName;
        var sortedData = StringsSort.Sort( projectDirectory + "\\data.txt");
        Assert.AreEqual(new List<string>(){ "a", "b", "c", "d", "e","f"}, sortedData.Result);
    }
}