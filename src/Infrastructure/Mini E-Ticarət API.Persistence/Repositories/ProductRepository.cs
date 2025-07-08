using Microsoft.EntityFrameworkCore;
using Mini_E_Ticarət_API.Application.Abstracts.Repositories;
using Mini_E_Ticarət_API.Domain.Entities;
using Mini_E_Ticarət_API.Persistence.Contexts;

namespace Mini_E_Ticarət_API.Persistence.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly Mini_E_Ticarət_APIDbContext _context;

    public ProductRepository(Mini_E_Ticarət_APIDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetMyProductsAsync(string userId)
    {
        return await GetByFiltered(p => p.AppUserId.ToString() == userId,
            new[] { (System.Linq.Expressions.Expression<Func<Product, object>>)(p => p.Category), p => p.Images })
            .ToListAsync();
    }

    public async Task<List<Product>> GetFilteredAsync(Guid? categoryId, decimal? minPrice, decimal? maxPrice, string? search)
    {
        var query = GetByFiltered(include: new[] { (System.Linq.Expressions.Expression<Func<Product, object>>)(p => p.Category), p => p.Images });

        if (categoryId.HasValue)
            query = query.Where(p => p.CategoryId == categoryId);

        if (minPrice.HasValue)
            query = query.Where(p => p.Price >= minPrice);

        if (maxPrice.HasValue)
            query = query.Where(p => p.Price <= maxPrice);

        if (!string.IsNullOrEmpty(search))
            query = query.Where(p => p.Name.ToLower().Contains(search.ToLower()));

        return await query.ToListAsync();
    }
}
