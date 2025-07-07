using FluentValidation;
using Mini_E_Ticarət_API.Application.DTOs.ImageDtos;

namespace Mini_E_Ticarət_API.Application.Validations.ImageValidators;

public class ImageUpdateDtoValidator : AbstractValidator<ImageUpdateDto>
{
    public ImageUpdateDtoValidator()
    {
        RuleFor(i => i.ImageUrl)
            .NotEmpty().WithMessage("Image URL must not be empty.")
            .MaximumLength(500).WithMessage("Image URL is too long. Maximum 500 characters allowed.");
    }
}
