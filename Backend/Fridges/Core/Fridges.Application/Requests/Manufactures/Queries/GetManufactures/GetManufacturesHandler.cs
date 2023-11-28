using Fridges.Application.Common;
using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Manufactures.Queries.GetManufactures;

public class GetManufacturesHandler(
        IManufactureRepository manufactureRepository,
        IFridgesApplicationConfiguration applicationConfiguration)
    : IRequestHandler<GetManufacturesRequest, List<Manufacture>>
{
    public async Task<List<Manufacture>> Handle(GetManufacturesRequest request, CancellationToken cancellationToken)
    {
        var manufacture = await manufactureRepository.GetManufacturesAsync(
            applicationConfiguration.PageSize * (request.Page - 1),
            applicationConfiguration.PageSize,
            cancellationToken);
        
        return manufacture;
    }
}