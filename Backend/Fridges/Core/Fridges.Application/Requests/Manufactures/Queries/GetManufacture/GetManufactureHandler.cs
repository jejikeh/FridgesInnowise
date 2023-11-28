using Fridges.Application.Common.Exceptions;
using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Manufactures.Queries.GetManufacture;

public class GetManufactureHandler(IManufactureRepository manufactureRepository) 
    : IRequestHandler<GetManufactureRequest, Manufacture>
{
    public async Task<Manufacture> Handle(GetManufactureRequest request, CancellationToken cancellationToken)
    {
        var manufacture = await manufactureRepository.GetManufactureAsync(request.Id, cancellationToken);
        if (manufacture is null)
        {
            throw new HttpNotFoundException($"Manufacture with ID={request.Id} not found");
        }

        return manufacture;
    }
}