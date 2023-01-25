namespace ControlTasks;

public class SortStrings
{
    private static readonly char[] SEPARATORS = new []{';', ',', ' ', '-', '.'};

    public static async Task Sort(string filepath)
    {
        var data = new List<string>();
        using (StreamReader stream = new StreamReader(filepath))
        {
            while (await stream.ReadLineAsync() is { } line)
            {
                var words = line.Split(SEPARATORS, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    data.Add(word);
                }
            }
        }
    }

    private void MergeSort(List<string> array, int begin, int end)
    {
        if (begin < end)
        {
            var middle = (begin + end) / 2;
            MergeSort(array, begin, middle);
            MergeSort(array, middle+1, end);
            Merge(array, begin, middle, end);
        }
    }

    private void Merge(List<string> array, int begin, int middle, int end)
    {
        var leftLength = middle - begin + 1;
        var rightLength = end - middle;
        var leftArray = new string[leftLength];
        var rightArray = new string[rightLength];
        for (int i = 0; i < leftLength; i++)
        {
            leftArray[i] = array[begin + i];
        }

        for (int i = 0; i < rightLength; i++)
        {
            rightArray[i] = array[middle + i + 1];
        }

        var left = 0;
        var right = 0;
        

    }
}