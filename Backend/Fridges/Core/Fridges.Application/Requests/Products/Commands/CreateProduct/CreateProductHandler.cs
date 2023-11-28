using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Products.Commands.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductRequest, Product>
{
    private readonly IProductRepository _productRepository;

    public CreateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var product = new Product()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            DefaultQuantity = request.DefaultQuantity
        };

        var productCreated = await _productRepository.CreateProductAsync(product, cancellationToken);
        await _productRepository.SaveChangesAsync(cancellationToken);

        return productCreated;
    }
}