using Microsoft.Extensions.DependencyInjection;
using Mini_E_Ticarət_API.Application.Abstracts.Repositories;
using Mini_E_Ticarət_API.Application.Abstracts.Services;
using Mini_E_Ticarət_API.Persistence.Repositories;
using Mini_E_Ticarət_API.Persistence.Services;

namespace Mini_E_Ticarət_API.Persistence;

public static class ServiceRegistration
{
    public static void RegisterService(this IServiceCollection services)
    {
        #region Repositories
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        #endregion

        #region Services
        services.AddScoped<ICategoryService, CategoryService>();
        #endregion

    }
}
