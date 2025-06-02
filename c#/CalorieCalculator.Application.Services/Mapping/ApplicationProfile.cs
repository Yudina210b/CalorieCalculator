using Application.Models.FoodProduct;
using Application.Models.Meal;
using Application.Models.User;
using AutoMapper;
using Application.Models;
using Domain.Entities;

namespace Application.Services.Mapping
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            // User mappings
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.DailyCalories,
                    opt => opt.Ignore()); // Будет рассчитываться отдельно

            // FoodProduct mappings
            CreateMap<FoodProduct, FoodProductModel>();

            // Meal mappings
            CreateMap<Meal, MealModel>();
            CreateMap<MealItem, MealItemModel>();
        }
    }
}