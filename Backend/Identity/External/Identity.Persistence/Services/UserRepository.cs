using Identity.Application.Common.Models.Requests.Register;
using Identity.Application.Services;
using Identity.Domain;
using Microsoft.AspNetCore.Identity;
using Results.Models;

namespace Identity.Persistence.Services;

public class UserRepository(UserManager<User> userManager) : IUserRepository
{
    public async Task<Result<User, RegisterError>> RegisterAsync(User user, string password, CancellationToken cancellationToken)
    {
        var result = await userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            return Result<User, RegisterError>.Success(user);
        }

        var errors = result.Errors.Select(error =>
            new Error(error.Description, 500));
            
        return Result<User, RegisterError>.Failure(new RegisterError("Failed to create user", 500, ErrorLevel.Important, errors.ToArray()));

    }
}