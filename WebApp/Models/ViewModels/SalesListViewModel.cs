using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Azure.Core;

namespace WebApp.Models.ViewModels;

public class SalesListViewModel
{
    public Guid Id { get; set; }
    
    [Display(Name="Date")]
    public DateOnly Date { get; set; }
    
    [Display(Name="From Time")]
    public TimeOnly FromTime { get; set; }
    
    [Display(Name="To Time")]
    public TimeOnly ToTime { get; set; }
    
    [Display(Name="Branch")]
    public string BranchName { get; set; }
    
    [Display(Name="Menu Item")]
    public string MenuItemName { get; set; }
    
    [Display(Name="Portion Size")]
    public string PortionSize { get; set; }
    
    [Display(Name = "Quantity")]
    public decimal Quantity { get; set; }
}