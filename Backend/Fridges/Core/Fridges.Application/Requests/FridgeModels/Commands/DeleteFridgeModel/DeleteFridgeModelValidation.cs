using FluentValidation;

namespace Fridges.Application.Requests.FridgeModels.Commands.DeleteFridgeModel;

public class DeleteFridgeModelValidation : AbstractValidator<DeleteFridgeModelRequest>
{
    public DeleteFridgeModelValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}