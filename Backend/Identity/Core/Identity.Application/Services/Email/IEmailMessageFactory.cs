using Identity.Application.Common.Models.Email;
using Identity.Domain;

namespace Identity.Application.Services.Email;

public interface IEmailMessageFactory
{
    public Task<ConfirmEmailMessage> CreateConfirmMessageAsync(User user);
}