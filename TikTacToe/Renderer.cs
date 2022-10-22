namespace csharp_course;

public class Renderer
{
    public void PrintGameBoard(FieldType[] a)
    {
        Console.Clear();
        Console.WriteLine("\r/---+---+---\\");
        for (int i = 0; i < 9; i+=3)
        {
            for (int j = 0; j < 3; j++)
            {
                if (a[j+i] == FieldType.Empty) Console.Write("|   ");
                else Console.Write($"| {a[j+i]} ");
            }
            Console.WriteLine("|");
            if (i != 6) Console.WriteLine("|---+---+---|");
            else Console.WriteLine("\r\\---+---+---/");
        }
    }
}