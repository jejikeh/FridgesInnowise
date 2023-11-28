using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Manufactures.Queries.GetManufactures;

public record GetManufacturesCommand(int Page) : IRequest<List<Manufacture>>;
