using FluentValidation;
using Mini_E_Ticarət_API.Application.DTOs.OrderDtos;

namespace Mini_E_Ticarət_API.Application.Validations.OrderValidators;

public class OrderCreateDtoValidator : AbstractValidator<OrderCreateDto>
{
    public OrderCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Order name is required.")
            .MaximumLength(100).WithMessage("Order name cannot exceed 100 characters.");

        RuleFor(x => x.BuyerId)
            .NotEqual(Guid.Empty).WithMessage("Buyer ID must be provided.");

        RuleFor(x => x.TotalPrice)
            .GreaterThan(0).WithMessage("Total price must be greater than 0.");
    }
}
