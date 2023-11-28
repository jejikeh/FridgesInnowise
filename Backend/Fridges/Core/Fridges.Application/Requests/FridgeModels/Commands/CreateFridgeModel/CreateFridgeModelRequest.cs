using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeModels.Commands.CreateFridgeModel;

public record CreateFridgeModelRequest(string Name, DateOnly ManufactureDate, Guid ManufactureId) : IRequest<FridgeModel>
{
    public CreateFridgeModelRequest() : this(string.Empty, DateOnly.MinValue, Guid.Empty)
    {
    }
}