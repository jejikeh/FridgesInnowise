using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeModels.Queries.GetFridgeModels;

public record GetFridgeModelsRequest(int Page) : IRequest<List<FridgeModel>>;