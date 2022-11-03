namespace Animals;

public abstract class Animal
{
    public string Name { get; set; } = string.Empty;
    public uint Age { get; set; }
    
    public abstract void Voice();
    public abstract void Walk();
    
}