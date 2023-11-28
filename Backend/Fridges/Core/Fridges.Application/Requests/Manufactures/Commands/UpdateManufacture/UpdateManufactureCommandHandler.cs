using Fridges.Application.Common.Exceptions;
using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Manufactures.Commands.UpdateManufacture;

public class UpdateManufactureCommandHandler(IManufactureRepository manufactureRepository) 
    : IRequestHandler<UpdateManufactureCommand, Manufacture>
{
    public async Task<Manufacture> Handle(UpdateManufactureCommand request, CancellationToken cancellationToken)
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