using Fridges.Application.Common;
using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeProducts.Queries.GetFridgeProducts;

public class GetFridgeProductsHandler(
        IFridgeProductRepository fridgeProductRepository,
        IFridgesApplicationConfiguration applicationConfiguration)
    : IRequestHandler<GetFridgeProductsRequest, List<FridgeProduct>>
{
    public async Task<List<FridgeProduct>> Handle(GetFridgeProductsRequest request, CancellationToken cancellationToken)
    {
        var fridgeProducts = await fridgeProductRepository.GetFridgeProductsAsync(
            request.FridgeId,
            applicationConfiguration.PageSize * (request.Page - 1),
            applicationConfiguration.PageSize,
            cancellationToken);

        return fridgeProducts;
    }
}