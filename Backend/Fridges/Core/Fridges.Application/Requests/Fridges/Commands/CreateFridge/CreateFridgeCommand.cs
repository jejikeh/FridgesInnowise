using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Fridges.Commands.CreateFridge;

public record CreateFridgeCommand(string OwnerName, Guid ModelId) : IRequest<Fridge>;