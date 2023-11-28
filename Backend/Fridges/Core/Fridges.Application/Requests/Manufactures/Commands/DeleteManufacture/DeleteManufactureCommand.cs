using MediatR;

namespace Fridges.Application.Requests.Manufactures.Commands.DeleteManufacture;

public record DeleteManufactureCommand(Guid Id) : IRequest;
