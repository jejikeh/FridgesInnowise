using Fridges.Application.Common.Exceptions;
using Fridges.Application.Services;
using MediatR;

namespace Fridges.Application.Requests.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler(IProductRepository productRepository) 
    : IRequestHandler<DeleteProductCommand>
{
    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
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