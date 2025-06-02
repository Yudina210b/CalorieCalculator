using Application.Models.Base;
using Domain.Enums;

namespace Application.Models.Meal
{
    public record CreateMealModel(
        Guid UserId,
        DateTime Date,
        MealType Type) : ICreateModel;
}