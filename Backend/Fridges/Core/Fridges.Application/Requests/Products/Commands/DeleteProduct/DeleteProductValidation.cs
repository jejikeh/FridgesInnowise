using FluentValidation;

namespace Fridges.Application.Requests.Products.Commands.DeleteProduct;

public class DeleteProductValidation : AbstractValidator<DeleteProductRequest>
{
    public DeleteProductValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}