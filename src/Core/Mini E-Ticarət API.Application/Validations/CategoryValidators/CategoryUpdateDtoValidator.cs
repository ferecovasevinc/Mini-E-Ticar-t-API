using FluentValidation;
using Mini_E_Ticarət_API.Application.DTOs.CategoryDtos;

namespace Mini_E_Ticarət_API.Application.Validations.CategoryValidators;

public class CategoryUpdateDtoValidator : AbstractValidator<CategoryUpdateDto>
{
    public CategoryUpdateDtoValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name can not be null.")
            .MinimumLength(3).WithMessage("Name should be minimum 3 characters.");
    }
}
