using Identity.Application.Common.Configuration;
using Identity.Application.Common.Models.Requests.ResendConfirmEmail;
using Identity.Application.Services;
using Identity.Application.Services.Email;
using MediatR;
using Results.Models;

namespace Identity.Application.Requests.Commands.ResendConfirmEmail;

public class ResendConfirmEmailHandler(IUserRepository repository, 
    IEmailService emailService,
    IEmailMessageFactory emailMessageFactory) 
    : IRequestHandler<ResendConfirmEmailRequest, Result<ResendConfirmEmailSuccess, ResendConfirmEmailError>>
{
    public async Task<Result<ResendConfirmEmailSuccess, ResendConfirmEmailError>> Handle(ResendConfirmEmailRequest request, CancellationToken cancellationToken)
    {
        var resultUserById = await repository.GetUserByIdAsync(request.Id);
        if (resultUserById.IsFailure)
        {
            return ResendConfirmEmailError.UserNotFound();
        }
        
        var user = resultUserById.GetSuccess();
        if (user!.EmailConfirmed)
        {
            return ResendConfirmEmailError.UserAlreadyConfirmed();
        }
        
        await emailService.SendEmailMessageAsync(
            await emailMessageFactory.CreateConfirmMessageAsync(user));
        
        return new ResendConfirmEmailSuccess();
    }
}