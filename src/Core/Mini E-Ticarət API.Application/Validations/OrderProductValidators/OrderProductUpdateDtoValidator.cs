using FluentValidation;
using Mini_E_Ticarət_API.Application.DTOs.OrderProductDtos;

namespace Mini_E_Ticarət_API.Application.Validations.OrderProductValidators;

public class OrderProductUpdateDtoValidator : AbstractValidator<OrderProductUpdateDto>
{
    public OrderProductUpdateDtoValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.Price).GreaterThan(0);
    }
}
