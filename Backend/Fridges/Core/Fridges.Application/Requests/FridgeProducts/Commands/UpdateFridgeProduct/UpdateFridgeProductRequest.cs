using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeProducts.Commands.UpdateFridgeProduct;

public record UpdateFridgeProductRequest(
    Guid Id,
    Guid? ProductId, 
    Guid? FridgeId, 
    int? Quantity) : IRequest<FridgeProduct>;
