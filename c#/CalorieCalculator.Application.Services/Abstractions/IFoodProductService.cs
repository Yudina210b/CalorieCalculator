using Application.Models.FoodProduct;
using Common.Enums;

namespace Application.Services.Abstractions
{
    public interface IFoodProductService
    {
        Task<FoodProductModel?> GetProductByIdAsync(Guid id, CancellationToken ct);
        Task<IEnumerable<FoodProductModel>> SearchProductsAsync(string name, CancellationToken ct);
        Task<CalculationStatus> AddProductAsync(CreateFoodProductModel product, CancellationToken ct);
    }
}