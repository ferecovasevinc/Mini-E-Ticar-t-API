namespace Mini_E_Ticarət_API.Application.DTOs.ProductDtos;

public record ProductListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string CategoryName { get; set; }
    public string FirstImageUrl { get; set; }
}
