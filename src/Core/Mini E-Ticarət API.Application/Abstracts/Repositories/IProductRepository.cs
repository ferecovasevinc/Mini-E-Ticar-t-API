using Mini_E_Ticarət_API.Domain.Entities;

namespace Mini_E_Ticarət_API.Application.Abstracts.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<List<Product>> GetMyProductsAsync(Guid userId);
    Task<List<Product>> GetFilteredAsync(Guid? categoryId, decimal? minPrice, decimal? maxPrice, string? search);
}
