namespace Mini_E_Ticarət_API.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; }
}
