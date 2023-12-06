using FluentValidation;

namespace Fridges.Application.Requests.FridgeProducts.Commands.CreateFridgeProduct;

public class CreateFridgeProductValidation : AbstractValidator<CreateFridgeProductRequest>
{
    public CreateFridgeProductValidation()
    {
        RuleFor(x => x.Quantity)
            .GreaterThan(0);
        
        RuleFor(x => x.ProductId)
            .NotEmpty()
            .NotEqual(Guid.Empty);
        
        RuleFor(x => x.FridgeId)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}