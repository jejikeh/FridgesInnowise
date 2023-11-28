using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Products.Queries.GetProduct;

public record GetProductCommand(Guid Id) : IRequest<Product>;
