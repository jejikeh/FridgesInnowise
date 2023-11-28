using MediatR;

namespace Fridges.Application.Requests.Manufactures.Commands.DeleteManufacture;

public record DeleteManufactureRequest(Guid Id) : IRequest;
