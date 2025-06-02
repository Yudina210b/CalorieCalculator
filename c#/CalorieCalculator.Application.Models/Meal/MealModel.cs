using Application.Models.Base;
using Domain.Enums;

namespace Application.Models.Meal
{
    public record MealModel(
        Guid Id,
        Guid UserId,
        DateTime Date,
        MealType Type) : IModel<Guid>;
}