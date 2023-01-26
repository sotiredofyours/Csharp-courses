namespace ControlTasks;

public class LeapYear : IUseConsole
{
    public bool isLeapYear(int year)
    {
        if (year < 0 || year > 9999) throw new ArgumentOutOfRangeException();
        if (year % 400 == 0) return true;  
        if (year % 100 == 100) return false;
        if (year % 4 == 0) return true;
        return false;
    }

    public void CLIOutput()
    {
        Console.WriteLine("Введите число вида YYYY");
        var number =Int32.Parse(Console.ReadLine());
        if (isLeapYear(number)) Console.WriteLine($"{number} год високосный");
        else Console.WriteLine($"{number} год не високосный");
    }
}