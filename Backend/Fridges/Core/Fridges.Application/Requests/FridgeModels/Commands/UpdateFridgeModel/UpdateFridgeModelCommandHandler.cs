using Fridges.Application.Common.Exceptions;
using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeModels.Commands.UpdateFridgeModel;

public class UpdateFridgeModelCommandHandler(
        IFridgeModelsRepository fridgeModelsRepository,
        IManufactureRepository manufactureRepository)
    : IRequestHandler<UpdateFridgeModelCommand, FridgeModel>
{
    public async Task<FridgeModel> Handle(
        UpdateFridgeModelCommand request, 
        CancellationToken cancellationToken)
    {
        var fridge = await fridgeModelsRepository.GetFridgeModelAsync(
            request.Id, 
            cancellationToken);

        if (fridge is null)
        {
            throw new HttpNotFoundException($"FridgeModel with ID = {request.Id} was not found");
        }
        
        var manufacture = await manufactureRepository.GetManufactureAsync(
            request.ManufactureId ?? fridge.ManufactureId, 
            cancellationToken);

        if (manufacture is null)
        {
            throw new HttpNotFoundException($"Manufacture with ID={request.ManufactureId} not found");
        }
        
        fridge.ManufactureId = request.ManufactureId ?? fridge.ManufactureId;
        fridge.Name = request.Name ?? fridge.Name;
        fridge.ManufactureDate = request.ManufactureDate ?? fridge.ManufactureDate;
        
        var updateFridgeModel = fridgeModelsRepository.UpdateFridgeModel(fridge);
        await fridgeModelsRepository.SaveChangesAsync(cancellationToken);
        
        return updateFridgeModel;
    }
}