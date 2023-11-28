using Identity.Application.Common.Models.Requests.GetRefreshTokens;
using Identity.Application.Services;
using MediatR;
using Results.Models;

namespace Identity.Application.Requests.Queries.GetRefreshTokens;

public class GetRefreshTokensHandler(
    IAuthorizeTokenService tokenService,
    IUserRepository userRepository) : IRequestHandler<GetRefreshTokensRequest, Result<GetRefreshTokensSuccess, GetRefreshTokensError>>
{
    public async Task<Result<GetRefreshTokensSuccess, GetRefreshTokensError>> Handle(GetRefreshTokensRequest request, CancellationToken cancellationToken)
    {
        var getUserResult = await userRepository.GetUserByIdAsync(request.UserId);
        if (getUserResult.IsFailure)
        {
            return GetRefreshTokensError.UserNotFound();
        }
        
        var refreshTokens = await tokenService
            .GetRefreshTokensAsync(request.UserId);
        
        return new GetRefreshTokensSuccess(refreshTokens);
    }
}