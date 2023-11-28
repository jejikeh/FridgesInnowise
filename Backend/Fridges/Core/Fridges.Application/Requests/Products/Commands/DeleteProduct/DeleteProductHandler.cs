using Fridges.Application.Common.Exceptions;
using Fridges.Application.Services;
using MediatR;

namespace Fridges.Application.Requests.Products.Commands.DeleteProduct;

public class DeleteProductHandler(IProductRepository productRepository) 
    : IRequestHandler<DeleteProductRequest>
{
    public async Task Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetProductAsync(request.Id, cancellationToken);
        if (product is null)
        {
            throw new HttpNotFoundException($"Product with ID={request.Id} not found.");
        }
        
        productRepository.DeleteProduct(product);
        await productRepository.SaveChangesAsync(cancellationToken);
    }
}