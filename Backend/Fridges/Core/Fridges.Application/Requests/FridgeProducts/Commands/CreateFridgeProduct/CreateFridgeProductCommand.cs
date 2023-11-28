using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeProducts.Commands.CreateFridgeProduct;

public record CreateFridgeProductCommand(
    Guid ProductId, 
    Guid FridgeId, 
    int Quantity) : IRequest<FridgeProduct>;