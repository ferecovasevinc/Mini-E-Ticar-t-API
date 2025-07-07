using Mini_E_Ticarət_API.Application.Abstracts.Repositories;
using Mini_E_Ticarət_API.Domain.Entities;
using Mini_E_Ticarət_API.Persistence.Contexts;

namespace Mini_E_Ticarət_API.Persistence.Repositories;

public class ImageRepository : Repository<Image>, IImageRepository
{
    public ImageRepository(Mini_E_Ticarət_APIDbContext context) : base(context)
    {
    }
}
