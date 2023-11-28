using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeModels.Queries.GetFridgeModel;

public record GetFridgeModelCommand(Guid Id) : IRequest<FridgeModel>;