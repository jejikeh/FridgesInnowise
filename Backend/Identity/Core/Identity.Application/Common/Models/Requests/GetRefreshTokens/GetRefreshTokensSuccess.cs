using Identity.Application.Common.Models.ViewModels;
using Identity.Domain;
using Results.Models;

namespace Identity.Application.Common.Models.Requests.GetRefreshTokens;

public class GetRefreshTokensSuccess : Success<IEnumerable<RefreshTokenViewModel>>
{
    public GetRefreshTokensSuccess(IEnumerable<RefreshToken> value) : base(value.Select(RefreshTokenViewModel.FromRefreshToken))
    {
    }
}