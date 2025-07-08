using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_E_Ticarət_API.Application.Abstracts.Services;
using Mini_E_Ticarət_API.Application.DTOs.OrderProductDtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mini_E_Ticarət_API.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderProductController : ControllerBase
{
    private readonly IOrderProductService _service;

    public OrderProductController(IOrderProductService service)
    {
        _service = service;
    }

    [HttpPost]
    [Authorize(Roles = "Admin,Seller")]
    public async Task<IActionResult> Create(OrderProductCreateDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpPut]
    [Authorize(Roles = "Admin,Seller")]
    public async Task<IActionResult> Update(OrderProductUpdateDto dto)
    {
        var result = await _service.UpdateAsync(dto);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _service.DeleteAsync(id);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        return StatusCode((int)result.StatusCode, result);
    }
}
