using FluentValidation;

namespace Fridges.Application.Requests.FridgeProducts.Queries.GetFridgeProducts;

public class GetFridgeProductsValidation : AbstractValidator<GetFridgeProductsRequest>
{
    public GetFridgeProductsValidation()
    {
        RuleFor(x => x.Page)
            .NotEmpty()
            .GreaterThan(0);
        
        RuleFor(x => x.FridgeId)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}