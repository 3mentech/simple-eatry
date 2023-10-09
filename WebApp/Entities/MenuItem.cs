namespace WebApp.Entities;

public class MenuItem
{
    public Guid Id { get; set; }
    public string Name { get; set; }= string.Empty;
    public Guid? MenuCategoryId { get; set; }
    public MenuCategory MenuCategory { get; set; }
    public MenuItem()
    {
        
    }
    
    public MenuItem(string name, Guid menuCategoryId)
    {
        Id = Guid.NewGuid();
        Name = name;
        MenuCategoryId = menuCategoryId;
    }
}