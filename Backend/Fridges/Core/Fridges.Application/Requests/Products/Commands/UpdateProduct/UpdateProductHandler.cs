using Fridges.Application.Common.Exceptions;
using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Products.Commands.UpdateProduct;

public class UpdateProductHandler(IProductRepository productRepository) 
    : IRequestHandler<UpdateProductRequest, Product>
{
    public async Task<Product> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetProductAsync(request.Id, cancellationToken);
        if (product is null)
        {
            throw new HttpNotFoundException($"Product with ID={request.Id} not found.");
        }
        
        product.Name = request.Name ?? product.Name;
        product.DefaultQuantity = request.DefaultQuantity ?? product.DefaultQuantity;
        
        var updateProduct = productRepository.UpdateProduct(product);
        await productRepository.SaveChangesAsync(cancellationToken);

        return updateProduct;
    }
}