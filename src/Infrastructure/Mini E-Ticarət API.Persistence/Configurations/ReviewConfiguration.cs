using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mini_E_Ticarət_API.Domain.Entities;

namespace Mini_E_Ticarət_API.Persistence.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.Property(r => r.Comment).HasMaxLength(500);
        builder.Property(r => r.Rating).IsRequired();

        builder.HasOne(r => r.AppUser)
               .WithMany(u => u.Reviews)
               .HasForeignKey(r => r.AppUserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Product)
               .WithMany(p => p.Reviews)
               .HasForeignKey(r => r.ProductId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
