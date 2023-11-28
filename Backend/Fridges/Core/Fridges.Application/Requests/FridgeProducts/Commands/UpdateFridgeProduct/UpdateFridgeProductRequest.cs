using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeProducts.Commands.UpdateFridgeProduct;

public record UpdateFridgeProductRequest(
    Guid Id,
    Guid? ProductId,
    Guid? FridgeId,
    int? Quantity) : IRequest<FridgeProduct>
{
    public UpdateFridgeProductRequest() : this(Guid.Empty, Guid.Empty, Guid.Empty, 0)
    {
        
    }
}
