using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Manufactures.Queries.GetManufactures;

public record GetManufacturesRequest(int Page) : IRequest<List<Manufacture>>;
