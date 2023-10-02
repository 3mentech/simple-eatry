using Microsoft.EntityFrameworkCore;
using WebApp.Entities;

namespace WebApp.Persistence;

public class SimpleEatryDbContext : DbContext
{
    public SimpleEatryDbContext(DbContextOptions<SimpleEatryDbContext> options): base(options)
    {
        
    }
    
    public DbSet<SalesTransaction> SalesTransactions { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
}