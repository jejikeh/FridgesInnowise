using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Products.Commands.UpdateProduct;

public record UpdateProductCommand(Guid Id, string? Name, int? DefaultQuantity) : IRequest<Product>;
