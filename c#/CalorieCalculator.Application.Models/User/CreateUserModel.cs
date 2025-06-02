using Application.Models.Base;
using Domain.Enums;

namespace Application.Models.User
{
    public record CreateUserModel(
        string Name,
        int Age,
        Gender Gender,
        decimal Weight,
        decimal Height,
        ActivityLevel ActivityLevel) : ICreateModel;
}