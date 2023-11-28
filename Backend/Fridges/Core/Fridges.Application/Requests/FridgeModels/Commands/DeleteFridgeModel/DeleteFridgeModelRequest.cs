using MediatR;

namespace Fridges.Application.Requests.FridgeModels.Commands.DeleteFridgeModel;

public record DeleteFridgeModelRequest(Guid Id) : IRequest;