using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mini_E_Ticarət_API.Domain.Entities;

namespace Mini_E_Ticarət_API.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(o => o.Name).IsRequired();
        builder.Property(o => o.Status).HasMaxLength(50);
    }
}
