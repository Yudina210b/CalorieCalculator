using Domain.Entities.Base;
using System.Linq.Expressions;

namespace Repositories.Abstractions
{
    public interface IRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        Task<TEntity?> GetByIdAsync(TId id, CancellationToken ct);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct);
        Task AddAsync(TEntity entity, CancellationToken ct);
        Task UpdateAsync(TEntity entity, CancellationToken ct);
        Task DeleteAsync(TEntity entity, CancellationToken ct);
        Task DeleteAsync(TId id, CancellationToken ct);
    }
}