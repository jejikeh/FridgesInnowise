using Identity.Application.Common.Models.Tokens;
using Results.Models;

namespace Identity.Application.Common.Models.Requests.UpdateAuthorizeToken;

public class UpdateAuthorizeTokenSuccess : Success<AuthorizeTokens>
{
    public UpdateAuthorizeTokenSuccess(AuthorizeTokens value) : base(value)
    {
    }
}