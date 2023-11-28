using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.FridgeModels.Commands.UpdateFridgeModel;

public record UpdateFridgeModelRequest(
    Guid Id,
    string? Name,
    DateOnly? ManufactureDate,
    Guid? ManufactureId)
    : IRequest<FridgeModel>;