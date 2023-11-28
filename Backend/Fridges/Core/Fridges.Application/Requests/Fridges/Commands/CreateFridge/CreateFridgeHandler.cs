using Fridges.Application.Common.Exceptions;
using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Fridges.Commands.CreateFridge;

public class CreateFridgeHandler(
        IFridgeModelsRepository fridgeModelsRepository,
        IFridgeRepository fridgeRepository)
    : IRequestHandler<CreateFridgeRequest, Fridge>
{
    public async Task<Fridge> Handle(
        CreateFridgeRequest request, 
        CancellationToken cancellationToken)
    {
        var fridgeModel = await fridgeModelsRepository.GetFridgeModelAsync(request.ModelId, cancellationToken);
        if (fridgeModel is null)
        {
            throw new HttpNotFoundException($"Fridge model with id {request.ModelId} not found.");
        }

        var fridge = new Fridge
        {
            Id = Guid.NewGuid(),
            OwnerName = request.OwnerName,
            ModelId = request.ModelId
        };
        
        var createFridge = await fridgeRepository.CreateFridgeAsync(fridge, cancellationToken);
        await fridgeRepository.SaveChangesAsync(cancellationToken);
        
        // NOTE(jejikeh): To prevent null properties in view model
        return await fridgeRepository.GetFridgeAsync(createFridge.Id, cancellationToken) 
               ?? throw new NullReferenceException();
    }
}