using FluentValidation;

namespace Fridges.Application.Requests.Manufactures.Commands.DeleteManufacture;

public class DeleteManufactureValidation : AbstractValidator<DeleteManufactureRequest>
{
    public DeleteManufactureValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}