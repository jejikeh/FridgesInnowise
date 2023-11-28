using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeModels.Commands.CreateFridgeModel;

public record CreateFridgeModelCommand(
    string Name,
    DateOnly ManufactureDate,
    Guid ManufactureId) 
    : IRequest<FridgeModel>;