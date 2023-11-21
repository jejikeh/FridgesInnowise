using Identity.Application.Common.Models.Requests.Register;
using Identity.Domain;
using Results.Models;

namespace Identity.Application.Services;

public interface IUserRepository
{
    public Task<Result<User, RegisterError>> RegisterAsync(string email, string userName, string password);
}