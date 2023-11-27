using Identity.Application.Common.Models.Requests.Login;
using Identity.Application.Common.Models.Tokens;
using MediatR;
using Results.Models;

namespace Identity.Application.Requests.Commands.Login;

public class LoginRequest : IRequest<Result<LoginSuccess, LoginError>>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}