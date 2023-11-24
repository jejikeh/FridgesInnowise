using Identity.Application.Common.Models.Email;
using Identity.Application.Services.Email;
using Identity.Domain;

namespace Identity.Infrastructure.Services.Email;

public class EmailMessageFactory : IEmailMessageFactory
{
    public Task<ConfirmEmailMessage> CreateConfirmMessageAsync(User user)
    {
        throw new NotImplementedException();
    }
}