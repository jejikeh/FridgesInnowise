using MediatR;

namespace Fridges.Application.Requests.Products.Commands.DeleteProduct;

public record DeleteProductRequest(Guid Id) : IRequest; 