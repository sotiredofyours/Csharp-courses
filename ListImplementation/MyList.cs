namespace ListImplementation;

public sealed class MyList<T>
{
    private T[] _items; // array of items

    private int _size;  
    
    public int Capacity
    {
        get => _items.Length;
        set
        {
            if (value < _size || value < 0) throw new ArgumentOutOfRangeException();
            if (value != _items.Length)
            {
                var newArray = new T[value];
                Array.Copy(_items, newArray, _size);
                _items = newArray;
            }
        }
    }

    public int Length => _size;

    public T this[int index]
    {
        get
        {
            if (index >= _size || index < 0) throw new ArgumentOutOfRangeException();
            return _items[index];
        }
        set
        {
            if (index >= _size || index < 0) throw new ArgumentOutOfRangeException();
            _items[index] = value;
        }
    }

    public MyList()
    {
        _items = Array.Empty<T>();
        _size = 0;
    }

    public MyList(int capacity)
    {
        _items = new T[capacity];
        _size = 0;
    }

    public MyList(ICollection<T> collection)
    {
        if (collection is null) throw new ArgumentException();
        var length = collection.Count;
        if (length == 0) _items = Array.Empty<T>();
        else
        {
            _items = new T[length];
            collection.CopyTo(_items, 0);
            _size = length;
        }
    }

    public void Add(T newItem)
    {
        var length = _items.Length;
        
        if (_size >= length)
        {
            var newCapacity = length == 0 ? 4 : length * 2;
            var newArray = new T[newCapacity];
            Array.Copy(_items, newArray, _size);
            _items = newArray;
            _items[_size] = newItem;
            _size++;
        }
        else
        {
            _items[_size++] = newItem;
        }
    }
    
    public bool Remove(T item)
    {
        var index = Array.IndexOf(_items, item);
        if (index == -1) return false;
        RemoveByIndex(index);
        return true;
    }

    // var itemsAfterItem = new T[_items.Length];
    // _size--;
    // for (int i = 0; i < _size; i++)
    // {
    //     if (i != index)
    //         itemsAfterItem[i] = _items[i];
    // }
    // _items = itemsAfterItem;
    // _items[_size] = default!;
    //
    //  in this version I need extra allocate for new Array. 
    public void RemoveByIndex(int index)
    {
        if (index >= _size || index < 0) throw new ArgumentOutOfRangeException();
        _size--;
        Array.Copy(_items, index+1, _items, index, _size - index);
        _items[_size] = default!;
    }
    
    
}