using Identity.Application.Common.Models.Requests.UpdateAuthorizeToken;
using MediatR;
using Results.Models;

namespace Identity.Application.Requests.Commands.UpdateAuthorizeToken;

public class UpdateAuthorizeTokenRequest : IRequest<Result<UpdateAuthorizeTokenSuccess, UpdateAuthorizeTokenError>>
{
    public Guid UserId { get; set; }
    public string RefreshToken { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}