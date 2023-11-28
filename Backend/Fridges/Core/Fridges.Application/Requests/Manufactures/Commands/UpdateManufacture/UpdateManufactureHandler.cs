using Fridges.Application.Common.Exceptions;
using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Manufactures.Commands.UpdateManufacture;

public class UpdateManufactureHandler(IManufactureRepository manufactureRepository) 
    : IRequestHandler<UpdateManufactureRequest, Manufacture>
{
    public async Task<Manufacture> Handle(UpdateManufactureRequest request, CancellationToken cancellationToken)
    {
        var manufacture = await manufactureRepository.GetManufactureAsync(request.Id, cancellationToken);
        if (manufacture is null)
        {
            throw new HttpNotFoundException($"Manufacture with ID={request.Id} not found");
        }
        
        manufacture.Name = request.Name ?? manufacture.Name;
        
        var updateManufacture = manufactureRepository.UpdateManufacture(manufacture);
        await manufactureRepository.SaveChangesAsync(cancellationToken);

        return updateManufacture;
    }
}