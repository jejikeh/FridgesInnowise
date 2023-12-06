using FluentValidation;

namespace Fridges.Application.Requests.FridgeModels.Queries.GetFridgeModels;

public class GetFridgeModelsValidation : AbstractValidator<GetFridgeModelsRequest>
{
    public GetFridgeModelsValidation()
    {
        RuleFor(x => x.Page)
            .NotEmpty()
            .GreaterThan(0);
    }
}