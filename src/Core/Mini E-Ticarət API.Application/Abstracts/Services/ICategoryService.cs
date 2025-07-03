using Mini_E_Ticarət_API.Application.DTOs.CategoryDtos;
using Mini_E_Ticarət_API.Application.Shared;

namespace Mini_E_Ticarət_API.Application.Abstracts.Services;

public interface ICategoryService
{
    Task<BaseResponse<string>> AddAsync(CategoryCreateDto dto);
    Task UpdateAsync(CategoryUpdateDto dto);
    Task DeleteAsync(int id);
    Task<CategoryCreateDto> GetAsync(int id);
    Task<CategoryUpdateDto> GetAsync(string search);
    Task<List<CategoryGetDto>> GetAll();
}
