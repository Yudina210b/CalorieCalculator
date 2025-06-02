using Application.Models.User;
using Common.Enums;
using Domain.Enums;

namespace Application.Services.Abstractions
{
    public interface IUserCalculationService
    {
        Task<UserModel?> GetUserByIdAsync(Guid id, CancellationToken ct);
        Task<decimal> CalculateDailyCaloriesAsync(Guid userId, CancellationToken ct);
        Task<CalculationStatus> UpdateUserActivityLevelAsync(
            Guid userId,
            ActivityLevel newLevel,
            CancellationToken ct);
    }
}