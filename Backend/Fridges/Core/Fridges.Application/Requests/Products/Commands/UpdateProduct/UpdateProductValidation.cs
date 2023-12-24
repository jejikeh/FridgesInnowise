using FluentValidation;

namespace Fridges.Application.Requests.Products.Commands.UpdateProduct;

public class UpdateProductValidation : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}