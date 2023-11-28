using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Products.Commands.CreateProduct;

public record CreateProductRequest(string Name, int DefaultQuantity) : IRequest<Product>
{
    public CreateProductRequest() : this(string.Empty, 0)
    {
        
    }
}
