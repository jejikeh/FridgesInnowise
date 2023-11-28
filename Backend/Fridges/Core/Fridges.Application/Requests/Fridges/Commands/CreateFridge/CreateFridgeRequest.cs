using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Fridges.Commands.CreateFridge;

public record CreateFridgeRequest(string OwnerName, Guid ModelId) : IRequest<Fridge>
{
    public CreateFridgeRequest() : this(string.Empty, Guid.Empty)
    {
        
    }
}