using FluentValidation;

namespace Fridges.Application.Requests.Products.Commands.CreateProduct;

public class CreateProductValidation : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);
        
        RuleFor(x => x.DefaultQuantity)
            .GreaterThan(0)
            .LessThanOrEqualTo(1000);
    }
}