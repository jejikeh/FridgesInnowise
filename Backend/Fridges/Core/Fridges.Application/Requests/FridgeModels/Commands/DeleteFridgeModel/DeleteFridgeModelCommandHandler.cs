using Fridges.Application.Common.Exceptions;
using Fridges.Application.Services;
using MediatR;

namespace Fridges.Application.Requests.FridgeModels.Commands.DeleteFridgeModel;

public class DeleteFridgeModelCommandHandler(IFridgeModelsRepository fridgeModelsRepository) : IRequestHandler<DeleteFridgeModelCommand>
{
    public async Task Handle(
        DeleteFridgeModelCommand request, 
        CancellationToken cancellationToken)
    {
        var fridge = await fridgeModelsRepository.GetFridgeModelAsync(
            request.Id, 
            cancellationToken);

        if (fridge is null)
        {
            throw new HttpNotFoundException($"FridgeModel with ID={request.Id} was not found");
        }

        fridgeModelsRepository.DeleteFridgeModel(fridge);
        await fridgeModelsRepository.SaveChangesAsync(cancellationToken);
    }
}