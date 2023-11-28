using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeProducts.Queries.GetFridgeProducts;

public record GetFridgeProductsRequest(Guid FridgeId, int Page) : IRequest<List<FridgeProduct>>;