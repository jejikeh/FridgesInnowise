using FluentValidation;

namespace Fridges.Application.Requests.Fridges.Queries.GetFridges;

public class GetFridgesValidation : AbstractValidator<GetFridgesRequest>
{
    public GetFridgesValidation()
    {
        RuleFor(x => x.Page)
            .NotEmpty()
            .GreaterThan(0);
    }
}