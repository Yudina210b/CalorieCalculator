namespace Application.Models.Meal
{
    public record MealItemModel(
        Guid Id,
        Guid MealId,
        Guid ProductId,
        Guid ProductName,
        decimal Quantity);
}