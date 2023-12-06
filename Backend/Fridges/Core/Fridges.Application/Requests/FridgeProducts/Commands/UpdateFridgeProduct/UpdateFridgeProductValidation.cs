using FluentValidation;

namespace Fridges.Application.Requests.FridgeProducts.Commands.UpdateFridgeProduct;

public class UpdateFridgeProductValidation : AbstractValidator<UpdateFridgeProductRequest>
{
    public UpdateFridgeProductValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
        
        RuleFor(x => x.ProductId)
            .NotEmpty()
            .NotEqual(Guid.Empty);
        
        RuleFor(x => x.FridgeId)
            .NotEmpty()
            .NotEqual(Guid.Empty);
        
        RuleFor(x => x.Quantity)
            .GreaterThan(0);
    }
}