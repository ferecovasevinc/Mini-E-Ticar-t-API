using Microsoft.EntityFrameworkCore;
using Mini_E_Ticarət_API.Application.Abstracts.Repositories;
using Mini_E_Ticarət_API.Domain.Entities;
using Mini_E_Ticarət_API.Persistence.Contexts;

namespace Mini_E_Ticarət_API.Persistence.Repositories;

public class FavouriteRepository : Repository<Favourite>, IFavouriteRepository
{
    private readonly Mini_E_Ticarət_APIDbContext _context;

    public FavouriteRepository(Mini_E_Ticarət_APIDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Favourite>> GetFavouritesByUserIdAsync(Guid userId)
    {
        return await _context.Favourites
                             .Where(f => f.AppUserId == userId)
                             .ToListAsync();
    }
}
