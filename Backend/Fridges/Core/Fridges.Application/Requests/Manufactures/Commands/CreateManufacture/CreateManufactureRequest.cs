using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Manufactures.Commands.CreateManufacture;

public record CreateManufactureRequest(string Name) : IRequest<Manufacture>;
