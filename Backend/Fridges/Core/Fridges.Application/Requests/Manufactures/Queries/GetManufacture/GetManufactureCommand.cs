using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Manufactures.Queries.GetManufacture;

public record GetManufactureCommand(Guid Id) : IRequest<Manufacture>;
