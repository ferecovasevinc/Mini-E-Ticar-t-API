using Microsoft.Extensions.DependencyInjection;
using Mini_E_Ticarət_API.Application.Abstracts.Repositories;
using Mini_E_Ticarət_API.Application.Abstracts.Services;
using Mini_E_Ticarət_API.Persistence.Repositories;
using Mini_E_Ticarət_API.Persistence.Services;
using Mini_E_Ticarət_API.Infrastructure.Services;


namespace Mini_E_Ticarət_API.Persistence;

public static class ServiceRegistration
{
    public static void RegisterService(this IServiceCollection services)
    {
        #region Repositories
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IFavouriteRepository, FavouriteRepository>();
        services.AddScoped<IImageRepository, ImageRepository>();
        services.AddScoped<IOrderProductRepository, OrderProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        #endregion

        #region Services
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IFavouriteService, FavouriteService>();
        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<IOrderProductService, OrderProductService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IEmailService, EmailService>();
        #endregion

    }
}
