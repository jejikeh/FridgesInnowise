using FluentValidation;

namespace Fridges.Application.Requests.Products.Queries.GetProduct;

public class GetProductValidation : AbstractValidator<GetProductRequest>
{
    public GetProductValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}