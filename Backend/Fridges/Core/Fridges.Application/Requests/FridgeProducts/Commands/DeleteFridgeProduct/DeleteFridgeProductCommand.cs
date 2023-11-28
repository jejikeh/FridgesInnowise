using MediatR;

namespace Fridges.Application.Requests.FridgeProducts.Commands.DeleteFridgeProduct;

public record DeleteFridgeProductCommand(Guid Id) : IRequest;
