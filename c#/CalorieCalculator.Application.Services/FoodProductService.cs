using Application.Models.FoodProduct;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.ValueObjects;
using Common.Enums;
using Domain.Entities;
using Repositories.Abstractions;

namespace Application.Services
{
    public sealed class FoodProductService : IFoodProductService
    {
        private readonly IFoodProductRepository _productRepository;
        private readonly IMapper _mapper;

        public FoodProductService(
            IFoodProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<FoodProductModel?> GetProductByIdAsync(Guid id, CancellationToken ct)
        {
            var product = await _productRepository.GetByIdAsync(id, ct);
            return product != null ? _mapper.Map<FoodProductModel>(product) : null;
        }

        public async Task<IEnumerable<FoodProductModel>> SearchProductsAsync(string name, CancellationToken ct)
        {
            // Предполагая, что репозиторий может принимать string для поиска
            var products = await _productRepository.SearchAsync(name, ct);
            return _mapper.Map<IEnumerable<FoodProductModel>>(products);
        }

        public async Task<CalculationStatus> AddProductAsync(CreateFoodProductModel model, CancellationToken ct)
        {
            try
            {
                // Создаем продукт, предполагая, что Name уже валидирован на уровне Application
                var product = new FoodProduct(
                    id: Guid.NewGuid(),
                    name: model.Name, // Прямая передача string
                    caloriesPer100g: model.CaloriesPer100g,
                    proteinsPer100g: model.ProteinsPer100g,
                    fatsPer100g: model.FatsPer100g,
                    carbohydratesPer100g: model.CarbohydratesPer100g);

                await _productRepository.AddAsync(product, ct);
                return CalculationStatus.Success;
            }
            catch (Exception ex) when (ex is ArgumentException or ArgumentNullException)
            {
                return CalculationStatus.FaultedInvalidInput;
            }
        }
    }
}