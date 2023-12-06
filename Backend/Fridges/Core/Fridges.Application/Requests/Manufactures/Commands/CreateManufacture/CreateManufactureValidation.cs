using FluentValidation;

namespace Fridges.Application.Requests.Manufactures.Commands.CreateManufacture;

public class CreateManufactureValidation : AbstractValidator<CreateManufactureRequest>
{
    public CreateManufactureValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);
    }
}