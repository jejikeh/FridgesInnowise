using Fridges.Application.Common;
using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeModels.Queries.GetFridgeModels;

public class GetFridgeModelsHandler(
        IFridgeModelsRepository fridgeModelsRepository,
        IFridgesApplicationConfiguration applicationConfiguration)
    : IRequestHandler<GetFridgeModelsRequest, List<FridgeModel>>
{
    public async Task<List<FridgeModel>> Handle(
        GetFridgeModelsRequest request, 
        CancellationToken cancellationToken)
    {
        var fridgeModels = await fridgeModelsRepository.GetFridgeModelsAsync(
            applicationConfiguration.PageSize * (request.Page - 1),
            applicationConfiguration.PageSize,
            cancellationToken);
        
        return fridgeModels;
    }
}