using Identity.Application.Common.Models.Requests.ConfirmEmail;
using Identity.Application.Common.Models.Requests.Errors;
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

    public Task<string> GenerateEmailConfirmationTokenAsync(User user)
    {
        return userManager.GenerateEmailConfirmationTokenAsync(user);
    }

    public async Task<Result<User?, NotFoundError>> GetUserByIdAsync(Guid userId)
    {
        var user = await userManager.FindByIdAsync(userId.ToString());
        return user is null 
            ? Result<User?, NotFoundError>.Failure(NotFoundError.UserNotFound()) 
            : Result<User?, NotFoundError>.Success(user);

    }

    public async Task<Result<ConfirmEmailSuccess, ConfirmEmailError>> ConfirmEmailAsync(User user, string requestToken)
    {
        var result = await userManager.ConfirmEmailAsync(user, requestToken);
        if (result.Succeeded)
        {
            return Result<ConfirmEmailSuccess, ConfirmEmailError>.Success(new ConfirmEmailSuccess("Email confirmed"));
        }
        
        var errors = result.Errors.Select(error =>
            new Error(error.Description, 500));
            
        return Result<ConfirmEmailSuccess, ConfirmEmailError>.Failure(new ConfirmEmailError("Failed to create user", 500, ErrorLevel.Important, errors.ToArray()));
    }
}