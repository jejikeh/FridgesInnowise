using Fridges.Application.Common.Exceptions;
using Fridges.Application.Services;
using MediatR;

namespace Fridges.Application.Requests.Manufactures.Commands.DeleteManufacture;

public class DeleteManufactureHandler(IManufactureRepository manufactureRepository) 
    : IRequestHandler<DeleteManufactureRequest>
{
    public async Task Handle(DeleteManufactureRequest request, CancellationToken cancellationToken)
    {
        var manufacture = await manufactureRepository.GetManufactureAsync(request.Id, cancellationToken);
        if (manufacture is null)
        {
            throw new HttpNotFoundException($"Manufacture with ID={request.Id} not found");
        }
        
        manufactureRepository.DeleteManufacture(manufacture);
        await manufactureRepository.SaveChangesAsync(cancellationToken);
    }
}