using Microsoft.EntityFrameworkCore;
using Mini_E_Ticarət_API.Application.Abstracts.Repositories;
using Mini_E_Ticarət_API.Application.Abstracts.Services;
using Mini_E_Ticarət_API.Application.DTOs.CategoryDtos;
using Mini_E_Ticarət_API.Application.Shared;
using Mini_E_Ticarət_API.Domain.Entities;
using System.Net;

namespace Mini_E_Ticarət_API.Persistence.Services;

public class CategoryService : ICategoryService
{
    private ICategoryRepository _categoryRepository { get; }
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<BaseResponse<string>> AddAsync(CategoryCreateDto dto)
    {
        var categoryDb = await _categoryRepository
            .GetByFiltered(c => c.Name.Trim().ToLower() == dto.Name.Trim().ToLower())
            .FirstOrDefaultAsync();
        if (categoryDb is not null)
        {
            return new BaseResponse<string>("This category already exist", HttpStatusCode.BadRequest);
        }

        Category category = new()
        {
            Name = dto.Name
        };
        await _categoryRepository.AddAsync(category);
        await _categoryRepository.SaveChangeAsync();
        return new BaseResponse<string>(HttpStatusCode.Created);
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<CategoryGetDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<CategoryCreateDto> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryUpdateDto> GetAsync(string search)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(CategoryUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
