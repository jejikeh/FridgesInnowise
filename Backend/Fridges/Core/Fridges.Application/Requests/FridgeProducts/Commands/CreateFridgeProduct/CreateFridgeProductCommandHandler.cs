using Fridges.Application.Common.Exceptions;
using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeProducts.Commands.CreateFridgeProduct;

public class CreateFridgeProductCommandHandler(IFridgeProductRepository fridgeProductRepository,
        IFridgeRepository fridgeRepository,
        IProductRepository productRepository)
    : IRequestHandler<CreateFridgeProductCommand, FridgeProduct>
{
    public async Task<FridgeProduct> Handle(CreateFridgeProductCommand request, CancellationToken cancellationToken)
    {
        var fridge = await fridgeRepository.GetFridgeAsync(request.FridgeId, cancellationToken);
        if (fridge is null)
        {
            throw new HttpNotFoundException($"Fridge with ID={request.FridgeId} not found.");
        }
        
        var product = await productRepository.GetProductAsync(request.ProductId, cancellationToken);
        if (product is null)
        {
            throw new HttpNotFoundException($"Product with ID={request.ProductId} not found.");
        }

        var fridgeProduct = new FridgeProduct
        {
            Id = Guid.NewGuid(),
            ProductId = request.ProductId,
            FridgeId = request.FridgeId,
            Quantity = request.Quantity
        };
        
        var fridgeProductCreated = await fridgeProductRepository.CreateFridgeProductAsync(fridgeProduct, cancellationToken);
        await fridgeProductRepository.SaveChangesAsync(cancellationToken);
        
        return fridgeProductCreated;
    }
}