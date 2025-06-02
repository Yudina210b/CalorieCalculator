using Domain.Entities;

namespace Repositories.Abstractions
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        // Дополнительные специфичные методы
        Task<User?> GetByNameAsync(string name, CancellationToken ct);
        Task<bool> ExistsAsync(string name, CancellationToken ct);
    }
}