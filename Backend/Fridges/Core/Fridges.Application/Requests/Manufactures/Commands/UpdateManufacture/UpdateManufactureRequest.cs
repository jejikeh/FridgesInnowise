using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Manufactures.Commands.UpdateManufacture;

public record UpdateManufactureRequest(Guid Id, string? Name) : IRequest<Manufacture>
{
    public UpdateManufactureRequest() : this(Guid.NewGuid(), string.Empty)
    {
        
    }
}