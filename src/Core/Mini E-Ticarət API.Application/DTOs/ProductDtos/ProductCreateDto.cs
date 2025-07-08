namespace Mini_E_Ticarət_API.Application.DTOs.ProductDtos;

public record ProductCreateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public List<string> ImageUrls { get; set; }
}
