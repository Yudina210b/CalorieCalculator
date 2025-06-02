using Domain.Entities;

namespace Repositories.Abstractions
{
    public interface IMealRepository
    {
        Task<Meal?> GetByIdAsync(Guid id, CancellationToken ct);
        Task<IEnumerable<Meal>> GetByUserIdAsync(Guid userId, CancellationToken ct);
        Task AddAsync(Meal meal, CancellationToken ct);
        Task AddItemAsync(MealItem item, CancellationToken ct);
    }
}