using Identity.Application.Common.Configuration;
using Identity.Application.Common.Configuration.Models;
using Identity.Application.Common.Models.Requests.Register;
using Identity.Application.Common.Models.Tokens;
using Identity.Application.Services;
using Identity.Application.Services.Email;
using Identity.Domain;
using MediatR;
using Results.Models;

namespace Identity.Application.Requests.Commands.Register;

public class RegisterHandler(
        IUserRepository userRepository,
        IEmailService emailService,
        IEmailMessageFactory emailMessageFactory,
        IIdentityApplicationConfiguration identityApplicationConfiguration)
    : IRequestHandler<RegisterRequest, Result<RegisterSuccess, RegisterError>>
{
    private readonly IdentityFeaturesConfiguration _identityFeaturesConfiguration = identityApplicationConfiguration.IdentityFeatures;
    
    public async Task<Result<RegisterSuccess, RegisterError>> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var responseFromRegister = await userRepository.RegisterAsync(
            new User(request.UserName, request.Email), 
            request.Password, 
            cancellationToken);
        
        if (responseFromRegister.IsFailure)
        {
            return responseFromRegister.GetFailure() ?? Error.InternalError<RegisterError>();
        }

        if (_identityFeaturesConfiguration.SendEmailConfirmation)
        {
            await emailService.SendEmailMessageAsync(
                await emailMessageFactory.CreateConfirmMessageAsync(responseFromRegister.GetSuccess()!));
        }

        return new RegisterSuccess(new AuthorizeTokens("AuthToken", "RefreshToken"));
    }
}