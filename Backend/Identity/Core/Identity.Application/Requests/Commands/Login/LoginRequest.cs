using Identity.Application.Common.Models.Requests.Login;
using Identity.Application.Common.Models.Tokens;
using MediatR;
using Results.Models;

namespace Identity.Application.Requests.Commands.Login;

public class LoginRequest : IRequest<Result<AuthorizeTokens, LoginError>>
{
    public string Email { get; set; }
    public string Password { get; set; }
}