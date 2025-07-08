using FluentValidation;
using Mini_E_Ticarət_API.Application.DTOs.ReviewDtos;

namespace Mini_E_Ticarət_API.Application.Validations.ReviewValidators;

public class ReviewUpdateDtoValidator : AbstractValidator<ReviewUpdateDto>
{
    public ReviewUpdateDtoValidator()
    {
        RuleFor(x => x.Comment).NotEmpty().MaximumLength(500);
        RuleFor(x => x.Rating).InclusiveBetween(1, 5);
    }
}
