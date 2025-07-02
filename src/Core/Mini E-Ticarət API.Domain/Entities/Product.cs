namespace Mini_E_Ticarət_API.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; } = true;

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }

    public ICollection<Image> Images { get; set; } = new List<Image>();
    public ICollection<Favourite> Favourites { get; set; } = new List<Favourite>();
    public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}
