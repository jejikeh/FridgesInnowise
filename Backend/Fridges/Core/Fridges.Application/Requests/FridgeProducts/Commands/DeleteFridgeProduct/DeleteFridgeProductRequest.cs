using MediatR;

namespace Fridges.Application.Requests.FridgeProducts.Commands.DeleteFridgeProduct;

public record DeleteFridgeProductRequest(Guid Id) : IRequest;
