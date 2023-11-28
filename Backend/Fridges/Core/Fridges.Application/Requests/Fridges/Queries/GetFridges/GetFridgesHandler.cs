using Fridges.Application.Common;
using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Fridges.Queries.GetFridges;

public class GetFridgesHandler(
        IFridgeRepository fridgeRepository,
        IFridgesApplicationConfiguration applicationConfiguration)
    : IRequestHandler<GetFridgesRequest, List<Fridge>>
{
    public async Task<List<Fridge>> Handle(GetFridgesRequest request, CancellationToken cancellationToken)
    {
        var fridges = await fridgeRepository.GetFridgesAsync(
            applicationConfiguration.PageSize * (request.Page - 1),
            applicationConfiguration.PageSize,
            cancellationToken);
        
        return fridges;
    }
}