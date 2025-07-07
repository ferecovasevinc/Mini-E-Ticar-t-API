using FluentValidation;
using Mini_E_Ticarət_API.Application.DTOs.UserDtos;

namespace Mini_E_Ticarət_API.Application.Validations.UserValidators;

public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
{
    public UserLoginDtoValidator()
    {
        RuleFor(ur => ur.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");

        RuleFor(ur => ur.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters");
    }
}
