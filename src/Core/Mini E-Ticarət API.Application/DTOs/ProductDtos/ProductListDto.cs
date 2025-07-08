namespace Mini_E_Ticarət_API.Application.DTOs.ProductDtos;

public record ProductListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string CategoryName { get; set; } = null!;
    public List<string> ImageUrls { get; set; } = new();
}
