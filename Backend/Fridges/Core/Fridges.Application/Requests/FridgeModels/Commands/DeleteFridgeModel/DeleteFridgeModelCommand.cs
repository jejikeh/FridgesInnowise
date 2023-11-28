using MediatR;

namespace Fridges.Application.Requests.FridgeModels.Commands.DeleteFridgeModel;

public record DeleteFridgeModelCommand(Guid Id) : IRequest;