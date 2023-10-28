using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Entities;

namespace WebApp.Persistence.Configurations;

public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.Property(x => x.Unit).HasConversion<string>();

        builder.HasKey(i => i.Id);

        // Configure the one-to-many relationship between Ingredient and RecipeItem
        builder.HasMany(i => i.Recipes)
            .WithOne(ri => ri.Ingredient)
            .HasForeignKey(ri => ri.IngredientId);
    }
}