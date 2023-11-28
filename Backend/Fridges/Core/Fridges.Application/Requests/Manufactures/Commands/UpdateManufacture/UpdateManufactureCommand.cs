using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Manufactures.Commands.UpdateManufacture;

public record UpdateManufactureCommand(Guid Id, string? Name) : IRequest<Manufacture>;