using FluentValidation;
using Mini_E_Ticarət_API.Application.DTOs.OrderProductDtos;

namespace Mini_E_Ticarət_API.Application.Validations.OrderProductValidators;

public class OrderProductCreateDtoValidator : AbstractValidator<OrderProductCreateDto>
{
    public OrderProductCreateDtoValidator()
    {
        RuleFor(x => x.OrderId).NotEmpty();
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.Price).GreaterThan(0);
    }
}
