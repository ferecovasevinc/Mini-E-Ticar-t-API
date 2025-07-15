using AutoMapper;
using Mini_E_Ticarət_API.Application.DTOs.CategoryDtos;
using CategoryEntity = Mini_E_Ticarət_API.Domain.Entities.Category;



namespace Mini_E_Ticarət_API.Application.MappingProfiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CategoryEntity, CategoryGetDto>();
        CreateMap<CategoryCreateDto, CategoryEntity>();
        CreateMap<CategoryUpdateDto, CategoryEntity>();
    }
}
