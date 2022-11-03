namespace Animals;

public class ZPatreot : Animal
{
    ZPatreot(){}

    public ZPatreot(string name, uint age)
    {
        Name = name;
        Age = age;
    }
    public override void Voice()
    {
        Console.WriteLine("Где вы были последние восемь лет?");
    }

    public override void Walk()
    {
        Console.WriteLine("Вы не понимаете! Путин просто защищает Россию от НАТО!");
    }
}