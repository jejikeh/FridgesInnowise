using FluentValidation;

namespace Fridges.Application.Requests.FridgeModels.Commands.CreateFridgeModel;

public class CreateFridgeModelValidation : AbstractValidator<CreateFridgeModelRequest>
{
    public CreateFridgeModelValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);
        
        RuleFor(x => x.ManufactureDate)
            .NotEmpty()
            .LessThan(DateOnly.FromDateTime(DateTime.Now));
        
        RuleFor(x => x.ManufactureId)
            .NotEmpty();
    }
}