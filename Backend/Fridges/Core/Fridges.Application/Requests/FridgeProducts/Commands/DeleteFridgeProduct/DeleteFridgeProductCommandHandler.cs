using Fridges.Application.Common.Exceptions;
using Fridges.Application.Services;
using MediatR;

namespace Fridges.Application.Requests.FridgeProducts.Commands.DeleteFridgeProduct;

public class DeleteFridgeProductCommandHandler(
        IFridgeProductRepository fridgeProductRepository)
    : IRequestHandler<DeleteFridgeProductCommand>
{
    public async Task Handle(DeleteFridgeProductCommand request, CancellationToken cancellationToken)
    {
        var fridgeProduct = await fridgeProductRepository.GetFridgeProductAsync(request.Id, cancellationToken);
        if (fridgeProduct is null)
        {
            throw new HttpNotFoundException($"FridgeProduct with ID={request.Id} not found.");
        }

        fridgeProductRepository.DeleteFridgeProduct(fridgeProduct);
        await fridgeProductRepository.SaveChangesAsync(cancellationToken);
    }
}