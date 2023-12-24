using FluentValidation;

namespace Fridges.Application.Requests.Manufactures.Queries.GetManufactureModels;

public class GetManufacturesModelsValidation : AbstractValidator<GetManufactureModelsRequest>
{
    public GetManufacturesModelsValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
        
        RuleFor(x => x.Page)
            .GreaterThan(0);
    }
}