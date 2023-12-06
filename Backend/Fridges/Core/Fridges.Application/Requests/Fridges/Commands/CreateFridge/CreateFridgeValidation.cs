using FluentValidation;

namespace Fridges.Application.Requests.Fridges.Commands.CreateFridge;

public class CreateFridgeValidation : AbstractValidator<CreateFridgeRequest>
{
    public CreateFridgeValidation()
    {
        RuleFor(x => x.OwnerName)
            .NotEmpty()
            .MaximumLength(50);
        
        RuleFor(x => x.ModelId)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}