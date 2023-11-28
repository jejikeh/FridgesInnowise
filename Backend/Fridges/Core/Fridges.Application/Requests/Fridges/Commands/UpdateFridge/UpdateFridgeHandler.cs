using Fridges.Application.Common.Exceptions;
using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Fridges.Commands.UpdateFridge;

public class UpdateFridgeHandler(
        IFridgeRepository fridgeRepository,
        IFridgeModelsRepository fridgeModelsRepository)
    : IRequestHandler<UpdateFridgeRequest, Fridge>
{
    public async Task<Fridge> Handle(
        UpdateFridgeRequest request, 
        CancellationToken cancellationToken)
    {
        var fridge = await fridgeRepository.GetFridgeAsync(request.Id, cancellationToken);
        if (fridge is null)
        {
            throw new HttpNotFoundException($"Fridge with ID={request.Id} not found.");
        }
        
        var model = await fridgeModelsRepository.GetFridgeModelAsync(
            request.ModelId ?? fridge.ModelId, 
            cancellationToken);

        if (model is null)
        {
            throw new HttpNotFoundException($"Model with ID={request.ModelId} not found");
        }
        
        fridge.ModelId = request.ModelId ?? fridge.ModelId;
        fridge.OwnerName = request.OwnerName ?? fridge.OwnerName;
        
        var updateFridge = fridgeRepository.UpdateFridge(fridge);
        await fridgeRepository.SaveChangesAsync(cancellationToken);

        return updateFridge;
    }
}