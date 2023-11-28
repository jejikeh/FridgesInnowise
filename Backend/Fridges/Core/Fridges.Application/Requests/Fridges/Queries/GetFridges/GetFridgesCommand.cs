using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Fridges.Queries.GetFridges;

public record GetFridgesCommand(int Page) : IRequest<List<Fridge>>;
