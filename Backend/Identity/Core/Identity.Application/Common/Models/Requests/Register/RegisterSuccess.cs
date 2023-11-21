using Identity.Application.Common.Models.Tokens;
using Results.Models;

namespace Identity.Application.Common.Models.Requests.Register;

public class RegisterSuccess : Success<AuthorizeTokens>
{
    public RegisterSuccess(AuthorizeTokens value, bool visible = true) : base(value, visible)
    {
    }
}