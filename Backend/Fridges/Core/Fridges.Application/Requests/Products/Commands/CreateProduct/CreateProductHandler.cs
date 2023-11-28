using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Products.Commands.CreateProduct;

public class CreateProductHandler(IProductRepository productRepository) 
    : IRequestHandler<CreateProductRequest, Product>
{
    public async Task<Product> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var product = new Product()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            DefaultQuantity = request.DefaultQuantity
        };

        var productCreated = await productRepository.CreateProductAsync(product, cancellationToken);
        await productRepository.SaveChangesAsync(cancellationToken);

        return productCreated;
    }
}