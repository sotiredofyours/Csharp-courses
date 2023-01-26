namespace ControlTasks;

public class InvertArrow : IUseConsole
{
    public void Run()
    {
        while (true)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.DownArrow:
                {
                    Console.Clear();
                    Console.WriteLine("\r↓");
                    break;
                }
                case ConsoleKey.RightArrow:
                {
                    Console.Clear();
                    Console.WriteLine("\r→");
                    break;
                }
                case ConsoleKey.LeftArrow:
                {
                    Console.Clear();
                    Console.WriteLine("\r←");
                    break;
                }
                case ConsoleKey.UpArrow:
                {
                    Console.Clear();
                    Console.WriteLine("\r↑");
                    break;
                }
                default:
                {
                    Environment.Exit(0);
                    break;
                }
            }
        }
    }
}