using Fridges.Application.Common.Exceptions;
using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeProducts.Commands.UpdateFridgeProduct;

public class UpdateFridgeProductHandler(
        IFridgeProductRepository fridgeProductRepository,
        IProductRepository productRepository,
        IFridgeRepository fridgeRepository)
    : IRequestHandler<UpdateFridgeProductRequest, FridgeProduct>
{
    public async Task<FridgeProduct> Handle(UpdateFridgeProductRequest request, CancellationToken cancellationToken)
    {
        var fridgeProduct = await fridgeProductRepository.GetFridgeProductAsync(request.Id, cancellationToken);
        if (fridgeProduct is null)
        {
            throw new HttpNotFoundException($"FridgeProduct with ID={request.Id} not found.");
        }
        
        var product = await productRepository.GetProductAsync(request.ProductId ?? fridgeProduct.ProductId, cancellationToken);
        if (product is null)
        {
            throw new HttpNotFoundException($"Product with ID={request.ProductId} not found.");
        }
        
        var fridge = await fridgeRepository.GetFridgeAsync(request.FridgeId ?? fridgeProduct.FridgeId, cancellationToken);
        if (fridge is null)
        {
            throw new HttpNotFoundException($"Fridge with ID={request.FridgeId} not found.");
        }
        
        fridgeProduct.ProductId = request.ProductId ?? fridgeProduct.ProductId;
        fridgeProduct.FridgeId = request.FridgeId ?? fridgeProduct.FridgeId;
        fridgeProduct.Quantity = request.Quantity ?? fridgeProduct.Quantity;
        
        var updateFridgeProduct = fridgeProductRepository.UpdateFridgeProduct(fridgeProduct);
        await fridgeProductRepository.SaveChangesAsync(cancellationToken);
        
        return updateFridgeProduct;
    }
}