using FluentValidation;
using Mini_E_Ticarət_API.Application.DTOs.ReviewDtos;

namespace Mini_E_Ticarət_API.Application.Validations.ReviewValidators;

public class ReviewCreateDtoValidator : AbstractValidator<ReviewCreateDto>
{
    public ReviewCreateDtoValidator()
    {
        RuleFor(x => x.Comment).NotEmpty().MaximumLength(500);
        RuleFor(x => x.Rating).InclusiveBetween(1, 5);
        RuleFor(x => x.ProductId).NotEqual(Guid.Empty);
    }
}
