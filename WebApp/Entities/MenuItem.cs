namespace WebApp.Entities;

public class MenuItem
{
    public Guid Id { get; set; }
    public string Name { get; set; }= string.Empty;

    public MenuItem()
    {
        
    }
    
    public MenuItem(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}