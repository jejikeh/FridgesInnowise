using Identity.Application.Common.Models.Email;
using Identity.Application.Services.Email;
using Identity.Infrastructure.Common.Configuration;
using Identity.Infrastructure.Common.Configuration.Models;
using MimeKit;

namespace Identity.Infrastructure.Services.Email;

public class EmailService(SmtpClientService smtpClientService, IIdentityInfrastructureConfiguration configuration) : IEmailService
{
    private readonly EmailConfiguration _emailConfiguration = configuration.EmailConfiguration;
    
    public Task SendEmailMessageAsync(EmailMessage message)
    {
        if (!smtpClientService.IsConnected)
        {
            smtpClientService.Connect();
        }
        
        return smtpClientService.SendAsync(CreateMimeMessage(message));
    }
    
    private MimeMessage CreateMimeMessage(EmailMessage emailMessage)
    {
        var mimeMessage = new MimeMessage();
        mimeMessage.From.Add(new MailboxAddress(
            _emailConfiguration.Username, 
            _emailConfiguration.From));
        
        mimeMessage.To.Add(MailboxAddress.Parse(emailMessage.Email));
        mimeMessage.Subject = emailMessage.Subject;
        mimeMessage.Body = new TextPart("html") { Text = emailMessage.GenerateHtml() };

        return mimeMessage;
    } 
}