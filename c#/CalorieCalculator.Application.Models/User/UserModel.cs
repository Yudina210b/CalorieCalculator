using Application.Models.Base;
using Domain.Enums;

namespace Application.Models.User
{
    public record UserModel(
        Guid Id,
        string Name,
        int Age,
        Gender Gender,
        decimal Weight,
        decimal Height,
        ActivityLevel ActivityLevel,
        decimal DailyCalories) : IModel<Guid>;
}