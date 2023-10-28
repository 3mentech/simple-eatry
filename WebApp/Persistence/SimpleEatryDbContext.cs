using Microsoft.EntityFrameworkCore;
using WebApp.Entities;
using WebApp.Persistence.Converters;

namespace WebApp.Persistence;

public class SimpleEatryDbContext : DbContext
{
    public SimpleEatryDbContext(DbContextOptions<SimpleEatryDbContext> options): base(options)
    {
        
    }
    
    public DbSet<SalesTransaction> SalesTransactions { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    
    public DbSet<MenuCategory> MenuCategories { get; set; }
    public DbSet<RecipeItem> RecipeItems { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Holiday> Holidays { get; set; }
    
    
    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        base.ConfigureConventions(builder);
        
        builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter, DateOnlyComparer>().HaveColumnType("date");
        
        builder.Properties<TimeOnly>()
            .HaveConversion<TimeOnlyConverter, TimeOnlyComparer>();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

}