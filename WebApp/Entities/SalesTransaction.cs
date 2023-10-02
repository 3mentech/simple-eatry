
namespace WebApp.Entities;

public class SalesTransaction
{   
    public Guid Id { get; set; }
    public DateTime TransactionTime { get; set; }
    public Branch Branch { get; set; }
    public Guid BranchId { get; set; }
    public MenuItem Item { get; set; }
    public Guid ItemId { get; set; }
    public Size Size { get; set; }

    public SalesTransaction()
    {
        Id = Guid.NewGuid();
    }
    
    public SalesTransaction(DateTime transactionTime, Branch branch, MenuItem item, Size size)
    {
        Id = Guid.NewGuid();
        TransactionTime = transactionTime;
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