using Identity.Application.Common.Models.Email;
using Identity.Application.Services.Email;

namespace Identity.Infrastructure.Services.Email;

public class EmailService : IEmailService
{
    public Task SendEmailMessageAsync(EmailMessage message)
    {
        throw new NotImplementedException();
    }
}