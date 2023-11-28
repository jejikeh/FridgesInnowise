using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeModels.Queries.GetFridgeModels;

public record GetFridgeModelsCommand(int Page) : IRequest<List<FridgeModel>>;