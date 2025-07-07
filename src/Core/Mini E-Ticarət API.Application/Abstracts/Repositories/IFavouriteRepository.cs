using Mini_E_Ticarət_API.Domain.Entities;

namespace Mini_E_Ticarət_API.Application.Abstracts.Repositories;

public interface IFavouriteRepository : IRepository<Favourite>
{
    Task<List<Favourite>> GetFavouritesByUserIdAsync(Guid userId);
}
