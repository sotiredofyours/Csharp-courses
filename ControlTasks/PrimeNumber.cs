namespace ControlTasks;

public static class PrimeNumber
{
    public static bool isPrime(int number)
    {
        if (number > 10000 || number < 0) throw new ArgumentOutOfRangeException();
        for (int i = 2; i < Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
}