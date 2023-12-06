using FluentValidation;

namespace Fridges.Application.Requests.Manufactures.Commands.DeleteManufacture;

public class DeleteManufactureValidation : AbstractValidator<DeleteManufactureRequest>
{
    public DeleteManufactureValidation()
    {
    }
}