namespace Mini_E_Ticarət_API.Application.DTOs.ProductDtos;

public record ProductUpdateDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
}
