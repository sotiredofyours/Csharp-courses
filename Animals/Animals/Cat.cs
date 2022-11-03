namespace Animals;

public class Cat : Animal
{
    Cat()
    {
    }

    public Cat(string name, uint age)
    {
        Name = name;
        Age = age;
    }

    public override void Voice()
    {
        Console.WriteLine("Meow!");
    }

    public override void Walk()
    {
        Console.WriteLine("Cat walking...");
    }
}