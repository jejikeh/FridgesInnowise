using Fridges.Application.Common.Exceptions;
using Fridges.Application.Services;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Manufactures.Commands.CreateManufacture;

public class CreateManufactureHandler(IManufactureRepository manufactureRepository)
    : IRequestHandler<CreateManufactureRequest, Manufacture>
{
    public async Task<Manufacture> Handle(CreateManufactureRequest request, CancellationToken cancellationToken)
    {
        var manufacture = new Manufacture()
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };
        
        var manufactureCreated = await manufactureRepository.CreateManufactureAsync(manufacture, cancellationToken);
        await manufactureRepository.SaveChangesAsync(cancellationToken);
        
        return manufactureCreated;
    }
}