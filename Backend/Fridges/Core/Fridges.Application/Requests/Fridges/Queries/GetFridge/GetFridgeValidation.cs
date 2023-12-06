using FluentValidation;

namespace Fridges.Application.Requests.Fridges.Queries.GetFridge;

public class GetFridgeValidation : AbstractValidator<GetFridgeRequest>
{
    public GetFridgeValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}