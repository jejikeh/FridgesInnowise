using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Fridges.Queries.GetFridge;

public record GetFridgeRequest(Guid Id) : IRequest<Fridge>;
