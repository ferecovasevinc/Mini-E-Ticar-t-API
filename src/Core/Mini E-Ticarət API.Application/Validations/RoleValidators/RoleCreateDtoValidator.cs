using FluentValidation;
using Mini_E_Ticarət_API.Application.DTOs.RoleDtos;

namespace Mini_E_Ticarət_API.Application.Validations.RoleValidators;

public class RoleCreateDtoValidator : AbstractValidator<RoleCreateDto>
{
    public RoleCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Role name is required");

        RuleFor(x => x.PermissionList)
            .NotEmpty().WithMessage("At least one permission must be selected");
    }
}
