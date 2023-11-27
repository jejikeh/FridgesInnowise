using Identity.Application.Common.Models.Requests.UpdateAuthorizeToken;
using Identity.Application.Services;
using MediatR;
using Results.Models;

namespace Identity.Application.Requests.Commands.UpdateAuthorizeToken;

public class UpdateAuthorizeTokenHandler(
    IUserRepository userRepository,
    IAuthorizeTokenService tokenService) : IRequestHandler<UpdateAuthorizeTokenRequest, Result<UpdateAuthorizeTokenSuccess, UpdateAuthorizeTokenError>>
{
    public async Task<Result<UpdateAuthorizeTokenSuccess, UpdateAuthorizeTokenError>> Handle(UpdateAuthorizeTokenRequest request, CancellationToken cancellationToken)
    {
        var userResult = await userRepository.GetUserByIdAsync(request.UserId);
        if (userResult.IsFailure)
        {
            return UpdateAuthorizeTokenError.UserNotFound();
        }
        
        var user = userResult.GetSuccess();
        
        var tokenValid = await tokenService.ValidateAuthorizeTokenAsync(request.UserId, request.RefreshToken);
        if (!tokenValid)
        {
            return UpdateAuthorizeTokenError.InvalidToken();
        }
        
        return new UpdateAuthorizeTokenSuccess(tokenService.GenerateAuthorizeToken(user!.Id, user.Email!));
    }
}