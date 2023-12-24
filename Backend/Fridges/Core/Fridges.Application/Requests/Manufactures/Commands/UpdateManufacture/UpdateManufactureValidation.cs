using FluentValidation;

namespace Fridges.Application.Requests.Manufactures.Commands.UpdateManufacture;

public class UpdateManufactureValidation : AbstractValidator<UpdateManufactureRequest>
{
    public UpdateManufactureValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);
    }
}