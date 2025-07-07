using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_E_Ticarət_API.Application.Abstracts.Services;
using Mini_E_Ticarət_API.Application.DTOs.CategoryDtos;
using Mini_E_Ticarət_API.Application.Shared;
using System.Net;

namespace Mini_E_Ticarət_API.WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    // GET: api/category
    [HttpGet]
    [ProducesResponseType(typeof(BaseResponse<List<CategoryGetDto>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _categoryService.GetAllAsync();
        return StatusCode((int)result.StatusCode, result);
    }

    // GET: api/category/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BaseResponse<CategoryGetDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _categoryService.GetByIdAsync(id);
        return StatusCode((int)result.StatusCode, result);
    }

    // POST: api/category
    [HttpPost]
    [Authorize(Policy = Permissions.Category.Create)]
    [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create([FromBody] CategoryCreateDto dto)
    {
        var result = await _categoryService.AddAsync(dto);
        return StatusCode((int)result.StatusCode, result);
    }

    // PUT: api/category/{id}
    [HttpPut("{id}")]
    [Authorize(Policy = Permissions.Category.Update)]
    [ProducesResponseType(typeof(BaseResponse<CategoryUpdateDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update(Guid id, [FromBody] CategoryUpdateDto dto)
    {
        dto.Id = id; // ID-ni DTO-ya əlavə et
        var result = await _categoryService.UpdateAsync(dto);
        return StatusCode((int)result.StatusCode, result);
    }

    // DELETE: api/category/{id}
    [HttpDelete("{id}")]
    [Authorize(Policy = Permissions.Category.Delete)]
    [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _categoryService.DeleteAsync(id);
        return StatusCode((int)result.StatusCode, result);
    }
}
