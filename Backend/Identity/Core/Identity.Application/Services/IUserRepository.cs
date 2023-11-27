using Identity.Application.Common.Models.Requests.ConfirmEmail;
using Identity.Application.Common.Models.Requests.Errors;
using Identity.Application.Common.Models.Requests.Register;
using Identity.Domain;
using Results.Models;

namespace Identity.Application.Services;

public interface IUserRepository
{
    public Task<Result<User, RegisterError>> RegisterAsync(User user, string password, CancellationToken cancellationToken);
    public Task<string> GenerateEmailConfirmationTokenAsync(User user);
    public Task<Result<User?, NotFoundError>> GetUserByIdAsync(Guid userId);
    public Task<Result<User?, NotFoundError>> GetUserByEmailAsync(string email);
    Task<Result<ConfirmEmailSuccess, ConfirmEmailError>> ConfirmEmailAsync(User user, string requestToken);
    Task<bool> CheckPasswordAsync(User user, string requestPassword);
}