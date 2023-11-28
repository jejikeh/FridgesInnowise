using MediatR;

namespace Fridges.Application.Requests.Products.Commands.DeleteProduct;

public record DeleteProductCommand(Guid Id) : IRequest; 