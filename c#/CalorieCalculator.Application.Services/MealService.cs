using Application.Models.Meal;
using Application.Services.Abstractions;
using AutoMapper;
using Common.Enums;
using Domain.Entities;
using Repositories.Abstractions;
using System.Linq.Expressions;

namespace Application.Services
{
    public sealed class MealService : IMealService
    {
        private readonly IMealRepository _mealRepository;
        private readonly IFoodProductRepository _productRepository;
        private readonly IMapper _mapper;

        public MealService(
            IMealRepository mealRepository,
            IFoodProductRepository productRepository,
            IMapper mapper)
        {
            _mealRepository = mealRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<MealModel?> GetMealByIdAsync(Guid id, CancellationToken ct)
        {
            var meal = await _mealRepository.GetByIdAsync(id, ct);
            return meal != null ? _mapper.Map<MealModel>(meal) : null;
        }

        public async Task<IEnumerable<MealModel>> GetUserMealsAsync(Guid userId, CancellationToken ct)
        {
            var meals = await _mealRepository.GetByUserIdAsync(userId, ct);
            return _mapper.Map<IEnumerable<MealModel>>(meals);
        }

        public async Task<CalculationStatus> AddMealAsync(CreateMealModel model, CancellationToken ct)
        {
            try
            {
                var meal = new Meal(
                    id: Guid.NewGuid(),
                    userId: model.UserId,
                    date: model.Date,
                    type: model.Type);

                await _mealRepository.AddAsync(meal, ct);
                return CalculationStatus.Success;
            }
            catch (Exception)
            {
                return CalculationStatus.FaultedDatabaseError;
            }
        }

        public async Task<CalculationStatus> AddProductToMealAsync(
            Guid mealId,
            Guid productId,
            decimal quantity,
            CancellationToken ct)
        {
            try
            {
                // Исправленная проверка существования meal
                var meal = await _mealRepository.GetByIdAsync(mealId, ct);
                if (meal == null)
                    return CalculationStatus.FaultedMealNotFound;

                // Исправленная проверка существования продукта
                var product = await _productRepository.GetByIdAsync(productId, ct);
                if (product == null)
                    return CalculationStatus.FaultedProductNotFound;

                var mealItem = new MealItem(
                    id: Guid.NewGuid(),
                    mealId: mealId,
                    productId: productId,
                    quantity: quantity);

                await _mealRepository.AddItemAsync(mealItem, ct);
                return CalculationStatus.Success;
            }
            catch (Exception)
            {
                return CalculationStatus.FaultedDatabaseError;
            }
        }
    }
}