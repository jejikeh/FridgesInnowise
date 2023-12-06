using FluentValidation;

namespace Fridges.Application.Requests.FridgeModels.Commands.UpdateFridgeModel;

public class UpdateFridgeModelValidation : AbstractValidator<UpdateFridgeModelRequest>
{
    public UpdateFridgeModelValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);
        
        RuleFor(x => x.ManufactureDate)
            .NotEmpty()
            .LessThan(DateOnly.FromDateTime(DateTime.Now));
        
        RuleFor(x => x.ManufactureId)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}