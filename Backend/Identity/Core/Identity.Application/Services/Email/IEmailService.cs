using Identity.Application.Common.Models.Email;

namespace Identity.Application.Services.Email;

public interface IEmailService
{
    public Task SendEmailMessageAsync(EmailMessage message);
}