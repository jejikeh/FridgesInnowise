using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeModels.Commands.UpdateFridgeModel;

public record UpdateFridgeModelRequest(
        Guid Id,
        string? Name,
        DateOnly? ManufactureDate,
        Guid? ManufactureId)
    : IRequest<FridgeModel>
{
    public UpdateFridgeModelRequest() : this(Guid.Empty, string.Empty, DateOnly.MinValue, Guid.Empty)
    {
        
    }
}