using NUnit.Framework;

namespace ListImplementation;


public class ListTest
{
    const int DefCapacityForTests = 4;
    [Test]
    public void ConstructorWithoutProperties()
    {
        var list = new MyList<int>();
        Assert.True(list.Capacity == 0);
        Assert.True(list.Length == 0);
    }

    [Test]
    public void ConstructorWithCapacity()
    {
        var list = new MyList<int>(DefCapacityForTests);
        Assert.True(list.Capacity == DefCapacityForTests);
        Assert.True(list.Length == 0);
    }

    [Test]
    public void ConstructorWithCollection()
    {
        var collection = new int[] {1, 2, 3};
        var list = new MyList<int>(collection);
        Assert.True(list.Length == collection.Length);
        for (int i = 0; i < list.Length; i++)
        {
            Assert.True(collection[i] == list[i]);
        }
        
    }

    [Test]
    public void ResetCapacity()
    {
        var array = new int[] {1, 2, 3, 4};
        var list = new MyList<int>(array);
        Assert.True(list.Capacity == 4);
        list.Add(5);
        Assert.True(list.Capacity == 8);
    }

    [Test]
    public void WrongCapacity()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var list = new MyList<int>();
            list.Capacity = -100;
        });
    }

    [Test]
    public void CapacityLessThenLength()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var list = new MyList<int>();
            list.Add(1);
            list.Capacity = 0;
        });
    }
    
    [Test]
    public void AddItemTest()
    {
        var list = new MyList<int>();
        list.Add(1);
        list.Add(2);
        Assert.True(list.Length == 2);
        Assert.True(list[0] == 1 && list[1] == 2);
        Assert.True(list.Capacity == 4);
    }

    [Test]
    public void IndexerTest()
    {
        var list = new MyList<string>();
        list.Add("item");
        Assert.True(list[0] == "item");
    }

    [Test]
    public void WrongIndexer()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var list = new MyList<int>();
            list[3] = 5;
        });
    }

    [Test]
    public void RemoveTest()
    {
        var list = new MyList<int>();
        list.Add(1);
        list.Remove(1);
        Assert.True(list.Length == 0);
    }
    
    [Test]
    public void WrongItemRemoveTest()
    {
        var list = new MyList<int>();
        list.Add(1);
        Assert.False(list.Remove(0));
    }

    [Test]
    public void RemoveByIndexTest()
    {
        var list = new MyList<int>();
        list.Add(1);
        list.RemoveByIndex(0);
        Assert.True(list.Length == 0);
    }

    [Test]
    public void WrongRemoveByIndexTest()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var list = new MyList<int>();
            list.Add(1);
            list.RemoveByIndex(2);
            Assert.True(list.Length == 0);
        });
    }
    
    
}
