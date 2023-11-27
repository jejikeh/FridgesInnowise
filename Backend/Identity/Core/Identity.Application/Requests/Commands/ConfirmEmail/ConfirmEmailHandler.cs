using System.Text;
using Identity.Application.Common.Models.Requests.ConfirmEmail;
using Identity.Application.Services;
using MediatR;
using Microsoft.AspNetCore.WebUtilities;
using Results.Models;

namespace Identity.Application.Requests.Commands.ConfirmEmail;

public class ConfirmEmailHandler(IUserRepository userRepository) :
    IRequestHandler<ConfirmEmailRequest, Result<ConfirmEmailSuccess, ConfirmEmailError>>
{
    public async Task<Result<ConfirmEmailSuccess, ConfirmEmailError>> Handle(ConfirmEmailRequest request, CancellationToken cancellationToken)
    {
        var resultUserById = await userRepository.GetUserByIdAsync(request.Id);
        if (resultUserById.IsFailure)
        {
            return ConfirmEmailError.UserNotFound();
        }
        
        var user = resultUserById.GetSuccess();

        if (user!.EmailConfirmed)
        {
            return ConfirmEmailError.UserAlreadyConfirmed();
        }
        
        var resultConfirmEmail = await userRepository.ConfirmEmailAsync(user!, Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Token)));
        
        return resultConfirmEmail.IsFailure 
            ? ConfirmEmailError.WrongToken()
            : new ConfirmEmailSuccess("Email confirmed");
    }
}