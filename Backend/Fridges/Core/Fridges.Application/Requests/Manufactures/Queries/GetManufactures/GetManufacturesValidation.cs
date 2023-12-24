using FluentValidation;

namespace Fridges.Application.Requests.Manufactures.Queries.GetManufactures;

public class GetManufacturesValidation : AbstractValidator<GetManufacturesRequest>
{
    public GetManufacturesValidation()
    {
        RuleFor(x => x.Page)
            .GreaterThan(0);
    }
}