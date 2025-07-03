using GoogleApi.Entities;
using MailChimp.Net.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_E_Ticarət_API.Application.Abstracts.Repositories;
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

    // GET: api/<CategoriesController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<CategoriesController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<CategoriesController>
    [HttpPost]
    [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Post([FromBody] CategoryCreateDto dto)
    {
        var result=await _categoryService.AddAsync(dto);
        return StatusCode((int)result.StatusCode,result);
    }

    // PUT api/<CategoriesController>/5
    [HttpPut("{id}")]
    public void Put(int id,[FromBody] string value)
    {
    }

    // DELETE api/<CategoriesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
