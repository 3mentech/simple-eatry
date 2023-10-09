using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.ViewModels;

public class MenuItemListViewModel
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    [Display(Name="Category")]
    public string Category { get; set; }
        
}