using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeModels.Queries.GetFridgeModel;

public record GetFridgeModelRequest(Guid Id) : IRequest<FridgeModel>;