using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Entities;

namespace WebApp.Persistence.Configurations;

public class RecipeItemConfiguration : IEntityTypeConfiguration<RecipeItem>
{
    public void Configure(EntityTypeBuilder<RecipeItem> builder)
    {
        builder.Property(x => x.Unit).HasConversion<string>();

        builder.HasKey(ri => ri.Id);

        // Configure the many-to-one relationship between RecipeItem and MenuItem
        builder.HasOne(ri => ri.MenuItem)
            .WithMany(mi => mi.Recipes)
            .HasForeignKey(ri => ri.MenuItemId);

        // Configure the many-to-one relationship between RecipeItem and Ingredient
        builder.HasOne(ri => ri.Ingredient)
            .WithMany(i => i.Recipes)
            .HasForeignKey(ri => ri.IngredientId);
    }
}