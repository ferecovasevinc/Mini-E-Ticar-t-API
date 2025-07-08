using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_E_Ticarət_API.Application.Abstracts.Services;
using Mini_E_Ticarət_API.Application.DTOs.ReviewDtos;
using Mini_E_Ticarət_API.Application.Shared.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mini_E_Ticarət_API.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewsController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetByProductId(Guid productId)
    {
        var result = await _reviewService.GetByProductIdAsync(productId);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpPost]
    [Authorize(Roles = "Buyer,Seller")]
    public async Task<IActionResult> Create(Guid productId, ReviewCreateDto dto)
    {
        var userId = User.GetUserId();
        dto = dto with { ProductId = productId };
        var result = await _reviewService.CreateAsync(dto, userId);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Buyer,Seller")]
    public async Task<IActionResult> Update(Guid id, ReviewUpdateDto dto)
    {
        var userId = User.GetUserId();
        dto = dto with { Id = id };
        var result = await _reviewService.UpdateAsync(dto, userId);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Buyer,Seller")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userId = User.GetUserId();
        var result = await _reviewService.DeleteAsync(id, userId);
        return StatusCode((int)result.StatusCode, result);
    }
}
