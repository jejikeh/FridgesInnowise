using MediatR;

namespace Fridges.Application.Requests.Fridges.Commands.DeleteFridge;

public record DeleteFridgeRequest(Guid Id) : IRequest;