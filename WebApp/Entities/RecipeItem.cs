using WebApp.Entities.Constants;

namespace WebApp.Entities;

public class RecipeItem
{
    public Guid Id { get; set; }
    public Guid IngredientId { get; set; }
    public Ingredient Ingredient { get; set; } = new();
    public decimal Quantity { get; set; }
    public UnitOfMeasurement Unit { get; set; }
    public Guid MenuItemId { get; set; }
    public MenuItem MenuItem { get; set; } = new MenuItem();
}