using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_E_Ticarət_API.Application.Abstracts.Services;
using Mini_E_Ticarət_API.Application.DTOs.FavouriteDtos;
using Mini_E_Ticarət_API.Application.Shared.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mini_E_Ticarət_API.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Buyer,Seller")]
public class FavouritesController : ControllerBase
{
    private readonly IFavouriteService _favouriteService;

    public FavouritesController(IFavouriteService favouriteService)
    {
        _favouriteService = favouriteService;
    }

    // GET: /api/favourites
    [HttpGet]
    public async Task<IActionResult> GetMyFavourites()
    {
        var userId = User.GetUserId();
        var response = await _favouriteService.GetByUserIdAsync(userId);
        return StatusCode((int)response.StatusCode, response);
    }

    // POST: /api/favourites/{productId}
    [HttpPost("{productId}")]
    public async Task<IActionResult> AddToFavourite(Guid productId)
    {
        var userId = User.GetUserId();
        var dto = new FavouriteCreateDto
        {
            Name = "Favourite",
            AppUserId = userId,
            ProductId = productId
        };
        var response = await _favouriteService.CreateAsync(dto);
        return StatusCode((int)response.StatusCode, response);
    }

    // DELETE: /api/favourites/{productId}
    [HttpDelete("{productId}")]
    public async Task<IActionResult> RemoveFromFavourite(Guid productId)
    {
        var userId = User.GetUserId();
        var userFavourites = await _favouriteService.GetByUserIdAsync(userId);
        var fav = userFavourites.Data?.FirstOrDefault(f => f.ProductId == productId);
        if (fav == null)
            return NotFound("Favourite not found");

        var response = await _favouriteService.DeleteAsync(fav.Id);
        return StatusCode((int)response.StatusCode, response);
    }
}
