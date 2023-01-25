namespace ControlTasks;

public class LeapYear
{
    
    public static bool isLeapYear(int year)
    {
        if (year < 0 || year > 9999) throw new ArgumentOutOfRangeException();
        if (year % 400 == 0) return true;  
        if (year % 100 == 100) return false;
        if (year % 4 == 0) return true;
        return false;
    }
}