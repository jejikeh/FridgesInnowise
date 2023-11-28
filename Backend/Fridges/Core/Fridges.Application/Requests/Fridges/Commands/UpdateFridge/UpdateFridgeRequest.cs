using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Fridges.Commands.UpdateFridge;

public record UpdateFridgeRequest(
    Guid Id,
    string? OwnerName,
    Guid? ModelId) : IRequest<Fridge>;