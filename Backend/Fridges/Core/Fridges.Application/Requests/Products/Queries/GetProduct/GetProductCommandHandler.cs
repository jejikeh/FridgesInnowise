using Fridges.Application.Common.Exceptions;
using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Products.Queries.GetProduct;

public class GetProductCommandHandler(IProductRepository productRepository)
    : IRequestHandler<GetProductCommand, Product>
{
    public async Task<Product> Handle(GetProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetProductAsync(request.Id, cancellationToken);
        if (product is null)
        {
            throw new HttpNotFoundException($"Product with id {request.Id} not found.");
        }

        return product;
    }
}