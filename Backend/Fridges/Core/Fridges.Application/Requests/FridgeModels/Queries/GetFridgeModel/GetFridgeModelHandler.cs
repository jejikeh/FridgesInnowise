using Fridges.Application.Common.Exceptions;
using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeModels.Queries.GetFridgeModel;

public class GetFridgeModelHandler(
        IFridgeModelsRepository fridgeModelsRepository)
    : IRequestHandler<GetFridgeModelRequest, FridgeModel>
{
    public async Task<FridgeModel> Handle(
        GetFridgeModelRequest request,
        CancellationToken cancellationToken)
    {
        var fridge = await fridgeModelsRepository.GetFridgeModelAsync(
            request.Id,
            cancellationToken);

        if (fridge is null)
        {
            throw new HttpNotFoundException($"FridgeModel ID={request.Id} not found");
        }

        return fridge;
    }
}