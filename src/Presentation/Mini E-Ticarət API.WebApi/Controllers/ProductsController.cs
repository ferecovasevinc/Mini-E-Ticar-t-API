using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_E_Ticarət_API.Application.Abstracts.Services;
using Mini_E_Ticarət_API.Application.DTOs.FavouriteDtos;
using Mini_E_Ticarət_API.Application.DTOs.ProductDtos;
using Mini_E_Ticarət_API.Application.Shared.Extensions;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mini_E_Ticarət_API.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IFavouriteService _favouriteService;

    public ProductsController(IProductService productService, IFavouriteService favouriteService)
    {
        _productService = productService;
        _favouriteService = favouriteService;
    }

    // GET: /api/products
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll([FromQuery] Guid? categoryId, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice, [FromQuery] string? search)
    {
        var response = await _productService.GetAllAsync(categoryId, minPrice, maxPrice, search);
        return StatusCode((int)response.StatusCode, response);
    }

    // GET: /api/products/{id}
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _productService.GetByIdAsync(id);
        return StatusCode((int)response.StatusCode, response);
    }

    // POST: /api/products
    [HttpPost]
    [Authorize(Roles = "Seller")]
    public async Task<IActionResult> Create([FromBody] ProductCreateDto dto)
    {
        var userId = User.GetUserId();
        var response = await _productService.CreateAsync(dto, userId);
        return StatusCode((int)response.StatusCode, response);
    }

    // PUT: /api/products/{id}
    [HttpPut("{id}")]
    [Authorize(Roles = "Seller")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ProductUpdateDto dto)
    {
        var userId = User.GetUserId();
        var response = await _productService.UpdateAsync(id, dto, userId);
        return StatusCode((int)response.StatusCode, response);
    }

    // DELETE: /api/products/{id}
    [HttpDelete("{id}")]
    [Authorize(Roles = "Seller")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userId = User.GetUserId();
        var response = await _productService.DeleteAsync(id, userId);
        return StatusCode((int)response.StatusCode, response);
    }

    // GET: /api/products/my
    [HttpGet("my")]
    [Authorize(Roles = "Seller")]
    public async Task<IActionResult> GetMyProducts()
    {
        var userId = User.GetUserId();
        var response = await _productService.GetMyProductsAsync(userId);
        return StatusCode((int)response.StatusCode, response);
    }

    // POST: /api/products/{id}/favorite
    [HttpPost("{id}/favorite")]
    [Authorize(Roles = "Buyer,Seller")]
    public async Task<IActionResult> AddToFavorite(Guid id)
    {
        var userId = User.GetUserId();
        var dto = new FavouriteCreateDto
        {
            Name = "Favourite", 
            AppUserId = userId,
            ProductId = id
        };
        var response = await _favouriteService.CreateAsync(dto);
        return StatusCode((int)response.StatusCode, response);
    }

    // DELETE: /api/products/{id}/favorite
    [HttpDelete("{id}/favorite")]
    [Authorize(Roles = "Buyer,Seller")]
    public async Task<IActionResult> RemoveFromFavorite(Guid id)
    {
        var userId = User.GetUserId();
        var userFavourites = await _favouriteService.GetByUserIdAsync(userId);
        var fav = userFavourites.Data?.FirstOrDefault(f => f.ProductId == id);
        if (fav == null)
            return NotFound("Favourite not found");

        var response = await _favouriteService.DeleteAsync(fav.Id);
        return StatusCode((int)response.StatusCode, response);
    }

    // GET: /api/products/favorites
    [HttpGet("favorites")]
    [Authorize(Roles = "Buyer,Seller")]
    public async Task<IActionResult> GetMyFavourites()
    {
        var userId = User.GetUserId();
        var response = await _favouriteService.GetByUserIdAsync(userId);
        return StatusCode((int)response.StatusCode, response);
    }
}
