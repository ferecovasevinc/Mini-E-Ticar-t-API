namespace Mini_E_Ticarət_API.Application.DTOs.ProductDtos;

public record ProductDetailDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    public string CategoryName { get; set; }
    public List<string> ImageUrls { get; set; }
    public string SellerEmail { get; set; }
}
