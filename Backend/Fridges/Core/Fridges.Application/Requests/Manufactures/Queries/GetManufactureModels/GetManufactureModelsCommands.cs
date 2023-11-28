using Fridges.Application.Common.Models;
using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Manufactures.Queries.GetManufactureModels;

public record GetManufactureModelsCommands(Guid Id, int Page) : IRequest<List<ManufactureFridgeModelDto>>;