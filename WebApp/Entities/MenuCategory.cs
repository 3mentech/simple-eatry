namespace WebApp.Entities;

public class MenuCategory
{
    public Guid Id { get; set; }
    public string Name { get; set; }= string.Empty;

    public MenuCategory()
    {
        
    }
    
    public MenuCategory(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}