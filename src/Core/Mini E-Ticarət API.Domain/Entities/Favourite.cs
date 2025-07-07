namespace Mini_E_Ticarət_API.Domain.Entities;

public class Favourite : BaseEntity
{
    public string Name { get; set; }

    public Guid AppUserId { get; set; }
    public AppUser AppUser { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}
