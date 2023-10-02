namespace WebApp.Entities;

public class Branch
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Branch()
    {
        
    }

    public Branch(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}