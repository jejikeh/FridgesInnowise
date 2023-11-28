using Fridges.Application.Common.Exceptions;
using Fridges.Application.Services;
using MediatR;

namespace Fridges.Application.Requests.Fridges.Commands.DeleteFridge;

public class DeleteFridgeHandler(
        IFridgeRepository fridgeRepository)
    : IRequestHandler<DeleteFridgeRequest>
{
    public async Task Handle(DeleteFridgeRequest request, CancellationToken cancellationToken)
    {
        var fridge = await fridgeRepository.GetFridgeAsync(request.Id, cancellationToken);
        if (fridge is null)
        {
            throw new HttpNotFoundException($"Fridge with ID={request.Id} not found.");
        }

        fridgeRepository.DeleteFridge(fridge);
        await fridgeRepository.SaveChangesAsync(cancellationToken);
    }
}