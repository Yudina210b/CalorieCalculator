using Application.Models.Meal;
using Common.Enums;

namespace Application.Services.Abstractions
{
    public interface IMealService
    {
        Task<MealModel?> GetMealByIdAsync(Guid id, CancellationToken ct);
        Task<IEnumerable<MealModel>> GetUserMealsAsync(Guid userId, CancellationToken ct);
        Task<CalculationStatus> AddMealAsync(CreateMealModel meal, CancellationToken ct);
        Task<CalculationStatus> AddProductToMealAsync(
            Guid mealId,
            Guid productId,
            decimal quantity,
            CancellationToken ct);
    }
}