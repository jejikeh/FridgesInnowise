using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Manufactures.Commands.CreateManufacture;

public record CreateManufactureCommand(string Name) : IRequest<Manufacture>;
