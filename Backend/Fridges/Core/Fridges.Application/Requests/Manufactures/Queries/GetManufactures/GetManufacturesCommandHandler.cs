using Fridges.Application.Common;
using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Manufactures.Queries.GetManufactures;

public class GetManufacturesCommandHandler(
        IManufactureRepository manufactureRepository,
        IFridgesApplicationConfiguration applicationConfiguration)
    : IRequestHandler<GetManufacturesCommand, List<Manufacture>>
{
    public async Task<List<Manufacture>> Handle(GetManufacturesCommand request, CancellationToken cancellationToken)
    {
        var manufacture = await manufactureRepository.GetManufacturesAsync(
            applicationConfiguration.PageSize * (request.Page - 1),
            applicationConfiguration.PageSize,
            cancellationToken);
        
        return manufacture;
    }
}