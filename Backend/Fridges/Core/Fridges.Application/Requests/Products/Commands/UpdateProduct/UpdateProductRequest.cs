using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Products.Commands.UpdateProduct;

public record UpdateProductRequest(Guid Id, string? Name, int? DefaultQuantity) : IRequest<Product>;
