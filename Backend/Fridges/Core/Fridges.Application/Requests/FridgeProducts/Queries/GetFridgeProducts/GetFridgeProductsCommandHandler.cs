using Fridges.Application.Common;
using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeProducts.Queries.GetFridgeProducts;

public class GetFridgeProductsCommandHandler(
        IFridgeProductRepository fridgeProductRepository,
        IFridgesApplicationConfiguration applicationConfiguration)
    : IRequestHandler<GetFridgeProductsCommand, List<FridgeProduct>>
{
    public async Task<List<FridgeProduct>> Handle(GetFridgeProductsCommand request, CancellationToken cancellationToken)
    {
        var fridgeProducts = await fridgeProductRepository.GetFridgeProductsAsync(
            request.FridgeId,
            applicationConfiguration.PageSize * (request.Page - 1),
            applicationConfiguration.PageSize,
            cancellationToken);

        return fridgeProducts;
    }
}