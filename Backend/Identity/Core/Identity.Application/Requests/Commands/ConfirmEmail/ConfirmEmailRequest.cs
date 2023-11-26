using Identity.Application.Common.Models.Requests.ConfirmEmail;
using MediatR;
using Results.Models;

namespace Identity.Application.Requests.Commands.ConfirmEmail;

public class ConfirmEmailRequest : IRequest<Result<ConfirmEmailSuccess, ConfirmEmailError>>
{
    public Guid Id { get; set; }
    public string Token { get; set; } = string.Empty;
}