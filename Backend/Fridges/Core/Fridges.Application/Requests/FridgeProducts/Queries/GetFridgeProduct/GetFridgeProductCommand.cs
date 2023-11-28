using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeProducts.Queries.GetFridgeProduct;

public record GetFridgeProductCommand(Guid Id) : IRequest<FridgeProduct>;