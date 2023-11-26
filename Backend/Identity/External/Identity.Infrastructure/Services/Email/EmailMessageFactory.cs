using System.Text;
using Identity.Application.Common.Models.Email;
using Identity.Application.Services;
using Identity.Application.Services.Email;
using Identity.Domain;
using Identity.Infrastructure.Common.Configuration;
using Microsoft.AspNetCore.WebUtilities;

namespace Identity.Infrastructure.Services.Email;

public class EmailMessageFactory(IUserRepository userRepository, IIdentityInfrastructureConfiguration configuration) : IEmailMessageFactory
{
    public async Task<ConfirmEmailMessage> CreateConfirmMessageAsync(User user)
    {
        var token = Encoding.UTF8.GetBytes(await userRepository.GenerateEmailConfirmationTokenAsync(user));
        var tokenEncoded = WebEncoders.Base64UrlEncode(token);

        return new ConfirmEmailMessage(
            "Confirm your email",
            user.Email!,
            user.UserName!,
            $"{configuration.Host}/api/user/confirm-email?Id={user.Id}&Token={tokenEncoded}");
    }
}