using Application.Models.Base;

namespace Application.Models.FoodProduct
{
    public record FoodProductModel(
        Guid Id,
        string Name,
        decimal CaloriesPer100g,
        decimal ProteinsPer100g,
        decimal FatsPer100g,
        decimal CarbohydratesPer100g) : IModel<Guid>;
}