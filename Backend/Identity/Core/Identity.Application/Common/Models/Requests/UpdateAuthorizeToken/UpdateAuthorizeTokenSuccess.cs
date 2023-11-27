using Identity.Application.Common.Models.Tokens;
using Identity.Application.Common.Models.ViewModels;
using Results.Models;

namespace Identity.Application.Common.Models.Requests.UpdateAuthorizeToken;

public class UpdateAuthorizeTokenSuccess : Success<AuthorizeTokensViewModel>
{
    public UpdateAuthorizeTokenSuccess(AuthorizeTokens value) 
        : base(AuthorizeTokensViewModel.FromAuthorizeTokens(value))
    {
    }
}