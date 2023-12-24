using FluentValidation;
using Fridges.Application.Requests.Products.Queries.GetProduct;

namespace Fridges.Application.Requests.Products.Queries.GetProducts;

public class GetProductsValidation : AbstractValidator<GetProductRequest>
{
    public GetProductsValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}