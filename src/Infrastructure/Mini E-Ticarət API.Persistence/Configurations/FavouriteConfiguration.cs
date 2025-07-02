using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mini_E_Ticarət_API.Domain.Entities;

namespace Mini_E_Ticarət_API.Persistence.Configurations;

public class FavouriteConfiguration : IEntityTypeConfiguration<Favourite>
{
    public void Configure(EntityTypeBuilder<Favourite> builder)
    {
        builder.Property(f => f.Name).IsRequired();

        builder.HasOne(f => f.AppUser)
               .WithMany(u => u.Favourites)
               .HasForeignKey(f => f.AppUserId)
               .OnDelete(DeleteBehavior.Restrict);


        builder.HasOne(f => f.Product)
               .WithMany(p => p.Favourites)
               .HasForeignKey(f => f.ProductId)
               .OnDelete(DeleteBehavior.Restrict);

    }
}
