using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.ViewModels;

public class SalesListViewModel
{
    public Guid Id { get; set; }
    
    [Display(Name="Time")]
    public DateTime Time { get; set; }
    
    [Display(Name="Branch")]
    public string BranchName { get; set; }
    
    [Display(Name="Menu Item")]
    public string MenuItemName { get; set; }
    
    [Display(Name="Portion Size")]
    public string PortionSize { get; set; }
}