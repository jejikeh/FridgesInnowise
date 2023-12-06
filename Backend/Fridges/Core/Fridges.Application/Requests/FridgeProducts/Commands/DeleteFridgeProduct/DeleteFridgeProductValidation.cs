using FluentValidation;

namespace Fridges.Application.Requests.FridgeProducts.Commands.DeleteFridgeProduct;

public class DeleteFridgeProductValidation : AbstractValidator<DeleteFridgeProductRequest>
{
    public DeleteFridgeProductValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}