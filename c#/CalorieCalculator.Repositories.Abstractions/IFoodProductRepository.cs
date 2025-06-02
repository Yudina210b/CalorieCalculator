using Domain.Entities;
using Domain.ValueObjects;

namespace Repositories.Abstractions
{
    public interface IFoodProductRepository : IRepository<FoodProduct, Guid>
    {
        Task<FoodProduct?> GetByIdAsync(Guid id, CancellationToken ct);
        Task<IEnumerable<FoodProduct>> GetByNameAsync(Name name, CancellationToken cancellationToken);
        Task<bool> ExistsByNameAsync(Name name, CancellationToken cancellationToken);
        Task<IEnumerable<FoodProduct>> SearchAsync(string name, CancellationToken ct);
    }
}