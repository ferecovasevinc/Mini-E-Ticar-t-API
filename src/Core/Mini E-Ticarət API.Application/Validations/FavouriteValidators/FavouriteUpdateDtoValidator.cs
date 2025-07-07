using FluentValidation;
using Mini_E_Ticarət_API.Application.DTOs.FavouriteDtos;

namespace Mini_E_Ticarət_API.Application.Validations.FavouriteValidators;

public class FavouriteUpdateDtoValidator : AbstractValidator<FavouriteUpdateDto>
{
    public FavouriteUpdateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name field is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
    }
}
