namespace Animals.Records;


public abstract record AbstractRecord
{
    
    public string Name { get; init; }
    public int Age { get; init; }
    
   
    public void Deconstruct(out string name, out int age) => (name, age) = (Name, Age);
};

public record ChildRecord : AbstractRecord
{
    public ChildRecord(){}
    public ChildRecord(string name, int age)
    {
        Name = name;
        Age = age;
    }
}