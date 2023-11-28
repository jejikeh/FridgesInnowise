using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeProducts.Commands.CreateFridgeProduct;

public record CreateFridgeProductRequest(
    Guid ProductId, 
    Guid FridgeId, 
    int Quantity) : IRequest<FridgeProduct>;