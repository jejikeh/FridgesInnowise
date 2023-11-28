using Fridges.Application.Common.Exceptions;
using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeModels.Commands.CreateFridgeModel;

public class CreateFridgeModelCommandHandler(
        IFridgeModelsRepository fridgeModelsRepository,
        IManufactureRepository manufactureRepository)
    : IRequestHandler<CreateFridgeModelCommand, FridgeModel>
{
    public async Task<FridgeModel> Handle(
        CreateFridgeModelCommand request, 
        CancellationToken cancellationToken)
    {
        var manufacture = await manufactureRepository.GetManufactureAsync(
            request.ManufactureId, 
            cancellationToken);

        if (manufacture is null)
        {
            throw new HttpNotFoundException($"Manufacture with ID={request.ManufactureId} not found");
        }

        var fridgeModel = new FridgeModel
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            ManufactureDate = request.ManufactureDate,
            ManufactureId = request.ManufactureId,
        };
        
        var fridgeModelCreated = await fridgeModelsRepository.CreateFridgeModelsAsync(fridgeModel, cancellationToken);
        await fridgeModelsRepository.SaveChangesAsync(cancellationToken);
        
        return fridgeModelCreated;
    }
}