namespace Mini_E_Ticarət_API.Application.DTOs.FavouriteDtos;

public record FavouriteListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid AppUserId { get; set; }
    public Guid ProductId { get; set; }
}
