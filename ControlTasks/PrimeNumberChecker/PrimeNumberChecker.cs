namespace ControlTasks;

public class PrimeNumberChecker : IUseConsole
{
    public bool isPrime(int number)
    {
        if (number > 10000 || number < 0) throw new ArgumentOutOfRangeException();
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
    public void Run()
    {
        Console.WriteLine("Введите число 0 < x <= 100000");
        var number =Int32.Parse(Console.ReadLine());
        if (isPrime(number)) Console.WriteLine($"Число {number} простое");
        else Console.WriteLine($"Число {number} не является простым");
    }
}