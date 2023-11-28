using Fridges.Application.Common;
using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Products.Queries.GetProducts;

public class GetProductCommandHandler(
        IProductRepository productRepository,
        IFridgesApplicationConfiguration applicationConfiguration)
    : IRequestHandler<GetProductsCommand, List<Product>>
{
    public async Task<List<Product>> Handle(GetProductsCommand request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetProductAsync(
            applicationConfiguration.PageSize * (request.Page - 1),
            applicationConfiguration.PageSize,
            cancellationToken);
        
        return products;
    }
}