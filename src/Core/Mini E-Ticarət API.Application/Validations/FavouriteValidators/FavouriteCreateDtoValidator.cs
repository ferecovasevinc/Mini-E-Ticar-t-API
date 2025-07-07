using FluentValidation;
using Mini_E_Ticarət_API.Application.DTOs.FavouriteDtos;

namespace Mini_E_Ticarət_API.Application.Validations.FavouriteValidators;

public class FavouriteCreateDtoValidator : AbstractValidator<FavouriteCreateDto>
{
    public FavouriteCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        RuleFor(x => x.AppUserId)
            .NotEmpty().WithMessage("AppUserId is required.");

        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("ProductId is required.");
    }
}
