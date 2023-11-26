using Identity.Infrastructure.Common.Configuration;
using Identity.Infrastructure.Common.Configuration.Models;
using MailKit.Net.Smtp;

namespace Identity.Infrastructure.Services.Email;

public class SmtpClientService(IIdentityInfrastructureConfiguration configuration) : SmtpClient
{
    private readonly EmailConfiguration _emailConfiguration = configuration.EmailConfiguration;

    public void Connect()
    {
        Connect(
            _emailConfiguration.Host,
            _emailConfiguration.Port,
            true);
        
        AuthenticationMechanisms.Add("XOAUTH2");
        
        Authenticate(
            _emailConfiguration.Username, 
            _emailConfiguration.Password);
    }
}