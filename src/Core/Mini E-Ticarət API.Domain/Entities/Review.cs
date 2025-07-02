namespace Mini_E_Ticarət_API.Domain.Entities;

public class Review : BaseEntity
{
    public string Comment { get; set; }
    public int Rating { get; set; }

    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }
}
