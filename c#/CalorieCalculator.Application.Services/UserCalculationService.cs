using Application.Models.User;
using Application.Services.Abstractions;
using AutoMapper;
using Common.Enums;
using Domain.Entities;
using Domain.Enums;
using Repositories.Abstractions;

namespace Application.Services
{
    public class UserCalculationService : IUserCalculationService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UserCalculationService(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<UserModel?> GetUserByIdAsync(Guid id, CancellationToken ct)
        {
            var user = await _userRepo.GetByIdAsync(id, ct);
            return user != null ? _mapper.Map<UserModel>(user) : null;
        }

        public async Task<decimal> CalculateDailyCaloriesAsync(Guid userId, CancellationToken ct)
        {
            var user = await _userRepo.GetByIdAsync(userId, ct);
            if (user == null) return 0;

            // Формула Миффлина-Сан Жеора (используем только публичные свойства)
            decimal bmr = user.Gender == Gender.Male
                ? (10 * user.Weight + 6.25m * user.Height - 5 * user.Age + 5)
                : (10 * user.Weight + 6.25m * user.Height - 5 * user.Age - 161);

            return bmr * GetActivityMultiplier(user.ActivityLevel);
        }

        private decimal GetActivityMultiplier(ActivityLevel level)
        {
            return level switch
            {
                ActivityLevel.LightlyActive => 1.375m,
                ActivityLevel.ModeratelyActive => 1.55m,
                ActivityLevel.VeryActive => 1.725m,
                ActivityLevel.ExtraActive => 1.9m,
                _ => 1.2m // По умолчанию для Sedentary
            };
        }

        public async Task<CalculationStatus> UpdateUserActivityLevelAsync(
            Guid userId,
            ActivityLevel newLevel,
            CancellationToken ct)
        {
            var user = await _userRepo.GetByIdAsync(userId, ct);
            if (user == null)
                return CalculationStatus.FaultedUserNotFound;

            // Создаем нового пользователя с обновленным уровнем активности
            var updatedUser = new User(
                user.Id,
                user.Name,
                user.Age,
                user.Gender,
                user.Weight,
                user.Height,
                newLevel);

            await _userRepo.UpdateAsync(updatedUser, ct);

            return CalculationStatus.Success;
        }
    }
}