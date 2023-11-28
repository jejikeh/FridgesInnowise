using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Fridges.Queries.GetFridges;

public record GetFridgesRequest(int Page) : IRequest<List<Fridge>>;
