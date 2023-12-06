using FluentValidation;

namespace Fridges.Application.Requests.Fridges.Commands.DeleteFridge;

public class DeleteFridgeValidation : AbstractValidator<DeleteFridgeRequest>
{
    public DeleteFridgeValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}