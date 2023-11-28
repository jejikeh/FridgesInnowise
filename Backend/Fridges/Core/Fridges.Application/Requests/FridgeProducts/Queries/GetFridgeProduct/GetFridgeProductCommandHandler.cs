using Fridges.Application.Common.Exceptions;
using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeProducts.Queries.GetFridgeProduct;

public class GetFridgeProductCommandHandler(
        IFridgeProductRepository fridgeProductRepository)
    : IRequestHandler<GetFridgeProductCommand, FridgeProduct>
{
    public async Task<FridgeProduct> Handle(GetFridgeProductCommand request, CancellationToken cancellationToken)
    {
        var fridgeModule = await fridgeProductRepository.GetFridgeProductAsync(request.Id, cancellationToken);
        if (fridgeModule is null)
        {
            throw new HttpNotFoundException($"FridgeProduct with ID={request.Id} not found.");
        }

        return fridgeModule;
    }
}