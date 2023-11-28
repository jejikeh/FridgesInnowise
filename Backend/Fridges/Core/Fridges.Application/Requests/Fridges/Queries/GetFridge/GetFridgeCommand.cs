using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Fridges.Queries.GetFridge;

public record GetFridgeCommand(Guid Id) : IRequest<Fridge>;
