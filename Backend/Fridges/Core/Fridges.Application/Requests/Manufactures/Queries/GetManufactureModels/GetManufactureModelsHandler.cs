using Fridges.Application.Common;
using Fridges.Application.Common.Models;
using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Manufactures.Queries.GetManufactureModels;

public class GetManufactureModelsHandler(
        IManufactureRepository manufactureRepository, 
        IFridgesApplicationConfiguration applicationConfiguration)
    : IRequestHandler<GetManufactureModelsRequest, List<ManufactureFridgeModelDto>>
{
    public async Task<List<ManufactureFridgeModelDto>> Handle(GetManufactureModelsRequest request, CancellationToken cancellationToken)
    {
        var fridge = await manufactureRepository.GetManufactureModelsAsync(
            request.Id, 
            applicationConfiguration.PageSize * (request.Page - 1), 
            applicationConfiguration.PageSize, 
            cancellationToken);
        
        return fridge.Select(ManufactureFridgeModelDto.FromManufactureModel).ToList();
    }
}