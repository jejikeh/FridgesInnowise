using Fridges.Application.Common.Exceptions;
using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Manufactures.Queries.GetManufacture;

public class GetManufactureCommandHandler(IManufactureRepository manufactureRepository) 
    : IRequestHandler<GetManufactureCommand, Manufacture>
{
    public async Task<Manufacture> Handle(GetManufactureCommand request, CancellationToken cancellationToken)
    {
        var manufacture = await manufactureRepository.GetManufactureAsync(request.Id, cancellationToken);
        if (manufacture is null)
        {
            throw new HttpNotFoundException($"Manufacture with ID={request.Id} not found");
        }

        return manufacture;
    }
}