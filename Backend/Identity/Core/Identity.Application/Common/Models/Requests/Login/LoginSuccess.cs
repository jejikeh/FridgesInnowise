using Identity.Application.Common.Models.Tokens;
using Identity.Application.Common.Models.ViewModels;
using Results.Models;

namespace Identity.Application.Common.Models.Requests.Login;

public class LoginSuccess : Success<AuthorizeTokensViewModel>
{
    public LoginSuccess(AuthorizeTokens value) 
        : base(AuthorizeTokensViewModel.FromAuthorizeTokens(value))
    {
    }
}