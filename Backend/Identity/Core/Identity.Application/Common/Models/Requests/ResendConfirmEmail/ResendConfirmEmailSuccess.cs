using Results.Models;

namespace Identity.Application.Common.Models.Requests.ResendConfirmEmail;

public class ResendConfirmEmailSuccess : Success<string>
{
    public ResendConfirmEmailSuccess() : base("Email sent")
    {
    }
}