namespace Identity.Application.Services;

public interface IEmailService
{
    public Task SendEmailAsync();
}