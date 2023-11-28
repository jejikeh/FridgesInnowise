using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeModels.Commands.CreateFridgeModel;

public record CreateFridgeModelRequest(
    string Name,
    DateOnly ManufactureDate,
    Guid ManufactureId) 
    : IRequest<FridgeModel>;