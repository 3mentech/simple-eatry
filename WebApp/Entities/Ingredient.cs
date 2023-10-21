using WebApp.Entities.Constants;

namespace WebApp.Entities;

public class Ingredient
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Cost { get; set; }
    public UnitOfMeasurement Unit { get; set; }
    public List<RecipeItem>? Recipes { get; set; }
}