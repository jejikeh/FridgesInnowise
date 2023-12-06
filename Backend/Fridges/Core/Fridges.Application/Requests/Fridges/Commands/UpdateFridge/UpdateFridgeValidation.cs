using FluentValidation;

namespace Fridges.Application.Requests.Fridges.Commands.UpdateFridge;

public class UpdateFridgeValidation : AbstractValidator<UpdateFridgeRequest>
{
    public UpdateFridgeValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
        
        RuleFor(x => x.OwnerName)
            .NotEmpty()
            .MaximumLength(50);
        
        RuleFor(x => x.ModelId)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}