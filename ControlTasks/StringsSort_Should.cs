using System.Reflection;
using Microsoft.VisualBasic.CompilerServices;
using NUnit.Framework;

namespace ControlTasks;

public class StringsSort_Should
{
    [Test]
    public void Sort()
    {
        var list = new List<string>() {"b", "c", "d", "e"};
        list.Sort();
        var listForMySort = new List<string>() {"b", "c", "d", "e"};
        SortStrings.MergeSort(listForMySort, 0, listForMySort.Count - 1);
        CollectionAssert.AreEqual(list, listForMySort);
    }

    [Test]
    public void EmptySort()
    {
        var list = new List<string>();
        SortStrings.MergeSort(list, 0, list.Count-1);
        CollectionAssert.AreEqual(new List<string>(), list);
    }

    [Test]
    public void SortFromFile()
    {
        string workingDirectory = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(workingDirectory)?.Parent.Parent?.FullName;
        var sortedData = SortStrings.Sort( projectDirectory + "\\data.txt");
        Assert.AreEqual(new List<string>(){ "a", "b", "c", "d", "e","f"}, sortedData.Result);
    }
}