using FluentValidation;
using Mini_E_Ticarət_API.Application.DTOs.OrderDtos;

namespace Mini_E_Ticarət_API.Application.Validations.OrderValidators;

public class OrderUpdateDtoValidator : AbstractValidator<OrderUpdateDto>
{
    public OrderUpdateDtoValidator()
    {
        RuleFor(x => x.Status)
            .NotEmpty().WithMessage("Order status is required.")
            .MaximumLength(50).WithMessage("Order status must not exceed 50 characters.");
    }
}
