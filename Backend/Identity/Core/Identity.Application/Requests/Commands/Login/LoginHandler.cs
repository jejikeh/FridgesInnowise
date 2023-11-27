using Identity.Application.Common.Models.Requests.Login;
using Identity.Application.Common.Models.Tokens;
using Identity.Application.Services;
using MediatR;
using Results.Models;

namespace Identity.Application.Requests.Commands.Login;

public class LoginHandler(
    IUserRepository userRepository,
    IAuthorizeTokenService tokenService) : IRequestHandler<LoginRequest, Result<AuthorizeTokens, LoginError>>
{
    public async Task<Result<AuthorizeTokens, LoginError>> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var resultUser = await userRepository.GetUserByEmailAsync(request.Email);
        if (resultUser.IsFailure)
        {
            return LoginError.InvalidCredentials();
        }
        
        var user = resultUser.GetSuccess();
        var isValidPassword = await userRepository.CheckPasswordAsync(user!, request.Password);
        
        if (!isValidPassword)
        {
            return LoginError.InvalidCredentials();
        }
         
        if (!user!.EmailConfirmed)
        {
            return LoginError.EmailIsNotConfirmed();
        }
        
        return tokenService.GenerateAuthorizeToken(user.Id, user.Email!);
    }
}