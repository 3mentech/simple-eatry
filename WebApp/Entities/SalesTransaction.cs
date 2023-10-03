
namespace WebApp.Entities;

public class SalesTransaction
{   
    public Guid Id { get; set; }
    
    public DateOnly Date { get; set; }
    
    public TimeOnly FromTime { get; set; }
    
    public TimeOnly ToTime { get; set; }
    public Branch Branch { get; set; }
    public Guid BranchId { get; set; }
    public MenuItem Item { get; set; }
    public Guid ItemId { get; set; }
    public Size Size { get; set; }

    public decimal Quantity { get; set; }

    public SalesTransaction()
    {
        Id = Guid.NewGuid();
    }
    
    public SalesTransaction(DateOnly date,TimeOnly fromTime, TimeOnly toTime, Branch branch, MenuItem item, Size size)
    {
        Id = Guid.NewGuid();
        Date = date;
        FromTime = fromTime;
        ToTime = toTime;
        Branch = branch;
        BranchId = branch.Id;
        Item = item;
        ItemId = item.Id;
        Size = size;
    }
}

public enum Size
{
    Count = 0,
    Quarter = 1,
    Half = 2,
    Full = 3
}