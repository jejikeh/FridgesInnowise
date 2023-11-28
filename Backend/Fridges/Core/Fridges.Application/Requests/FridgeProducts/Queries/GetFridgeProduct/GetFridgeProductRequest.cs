using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeProducts.Queries.GetFridgeProduct;

public record GetFridgeProductRequest(Guid Id) : IRequest<FridgeProduct>;