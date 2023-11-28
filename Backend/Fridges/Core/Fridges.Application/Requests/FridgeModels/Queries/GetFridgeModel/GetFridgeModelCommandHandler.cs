using Fridges.Application.Common.Exceptions;
using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeModels.Queries.GetFridgeModel;

public class GetFridgeModelCommandHandler(
        IFridgeModelsRepository fridgeModelsRepository)
    : IRequestHandler<GetFridgeModelCommand, FridgeModel>
{
    public async Task<FridgeModel> Handle(
        GetFridgeModelCommand request,
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