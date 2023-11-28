using Identity.Application.Common.Models.Requests.GetRefreshTokens;
using MediatR;
using Results.Models;

namespace Identity.Application.Requests.Queries.GetRefreshTokens;

public class GetRefreshTokensRequest : IRequest<Result<GetRefreshTokensSuccess, GetRefreshTokensError>>
{
    public Guid UserId { get; set; }
}