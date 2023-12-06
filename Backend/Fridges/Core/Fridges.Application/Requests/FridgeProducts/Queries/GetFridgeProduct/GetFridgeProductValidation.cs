using FluentValidation;

namespace Fridges.Application.Requests.FridgeProducts.Queries.GetFridgeProduct;

public class GetFridgeProductValidation : AbstractValidator<GetFridgeProductRequest>
{
    public GetFridgeProductValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}