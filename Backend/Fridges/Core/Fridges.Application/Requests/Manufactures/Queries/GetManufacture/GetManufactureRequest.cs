using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Manufactures.Queries.GetManufacture;

public record GetManufactureRequest(Guid Id) : IRequest<Manufacture>;
