using Identity.Application.Common.Models.Requests.ResendConfirmEmail;
using MediatR;
using Results.Models;

namespace Identity.Application.Requests.Commands.ResendConfirmEmail;

public class ResendConfirmEmailRequest : IRequest<Result<ResendConfirmEmailSuccess, ResendConfirmEmailError>>
{
    public Guid Id { get; set; }
}