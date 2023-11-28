using Fridges.Application.Common.Exceptions;
using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Fridges.Queries.GetFridge;

public class GetFridgeHandler(IFridgeRepository fridgeRepository) 
    : IRequestHandler<GetFridgeRequest, Fridge>
{
    public async Task<Fridge> Handle(GetFridgeRequest request, CancellationToken cancellationToken)
    {
        var fridge = await fridgeRepository.GetFridgeAsync(request.Id, cancellationToken);
        if (fridge is null)
        {
            throw new HttpNotFoundException($"Fridge with ID={request.Id} not found.");
        }
        
        return fridge;
    }
}