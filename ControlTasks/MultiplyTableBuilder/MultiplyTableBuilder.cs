namespace ControlTasks;

public class MultiplyTableBuilder : IUseConsole
{
    public void Run()
    {
        var table = BuildTable();
        for (int i = 0; i < table.GetLength(0); i++)
        {
            for (int j = 0; j < table.GetLength(1); j++)
            {
                Console.Write($"\t{table[i,j]}");
            }
            Console.WriteLine();
        }
    }

    public int[,] BuildTable()
    {
        var table = new int[10, 10];
        for (int i = 0; i < table.GetLength(0); i++)
        {
            for (int j = 0; j < table.GetLength(1); j++)
            {
                {
                    table[i, j] = (i + 1) * (j + 1);
                }
            } 
        }

        return table;
    }
}