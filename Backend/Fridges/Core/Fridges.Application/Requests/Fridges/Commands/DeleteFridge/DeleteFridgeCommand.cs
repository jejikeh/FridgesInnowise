using MediatR;

namespace Fridges.Application.Requests.Fridges.Commands.DeleteFridge;

public record DeleteFridgeCommand(Guid Id) : IRequest;