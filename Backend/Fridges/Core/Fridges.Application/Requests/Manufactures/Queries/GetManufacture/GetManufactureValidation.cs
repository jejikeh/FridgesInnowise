using FluentValidation;

namespace Fridges.Application.Requests.Manufactures.Queries.GetManufacture;

public class GetManufactureValidation : AbstractValidator<GetManufactureRequest>
{
    public GetManufactureValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}