using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mini_E_Ticarət_API.Domain.Entities;
using Mini_E_Ticarət_API.Persistence.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Mini_E_Ticarət_API.Persistence.Contexts;

public class Mini_E_Ticarət_APIDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
{
    public Mini_E_Ticarət_APIDbContext(DbContextOptions<Mini_E_Ticarət_APIDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }



    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Favourite> Favourites { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<Review> Reviews { get; set; }

}
