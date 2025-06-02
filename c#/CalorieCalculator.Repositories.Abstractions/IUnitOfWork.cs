namespace Repositories.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IFoodProductRepository FoodProductRepository { get; }
        IMealRepository MealRepository { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task BeginTransactionAsync(CancellationToken cancellationToken);
        Task CommitTransactionAsync(CancellationToken cancellationToken);
        Task RollbackTransactionAsync(CancellationToken cancellationToken);
    }
}