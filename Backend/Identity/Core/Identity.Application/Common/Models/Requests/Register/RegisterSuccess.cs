using Identity.Application.Common.Models.Tokens;
using Identity.Application.Common.Models.ViewModels;
using Results.Models;

namespace Identity.Application.Common.Models.Requests.Register;

public class RegisterSuccess : Success<AuthorizeTokensViewModel>
{
    public RegisterSuccess(AuthorizeTokens value) 
        : base(AuthorizeTokensViewModel.FromAuthorizeTokens(value))
    {
    }
}