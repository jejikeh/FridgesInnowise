using FluentValidation;

namespace Fridges.Application.Requests.FridgeModels.Queries.GetFridgeModel;

public class GetFridgeModelValidation : AbstractValidator<GetFridgeModelRequest>
{
    public GetFridgeModelValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}