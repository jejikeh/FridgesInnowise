using Results.Models;

namespace Identity.Application.Common.Models.Requests.ConfirmEmail;

public class ConfirmEmailSuccess : Success<string>
{
    public ConfirmEmailSuccess(string value) : base(value)
    {
    }
}