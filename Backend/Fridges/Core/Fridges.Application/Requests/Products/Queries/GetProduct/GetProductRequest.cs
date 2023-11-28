using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Products.Queries.GetProduct;

public record GetProductRequest(Guid Id) : IRequest<Product>;
