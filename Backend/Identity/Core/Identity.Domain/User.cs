using Microsoft.AspNetCore.Identity;

namespace Identity.Domain;

public sealed class User : IdentityUser<Guid>
{
    public User(string userName, string email)
    {
        Id = new Guid();
        
        UserName = userName;
        NormalizedEmail = userName.ToUpper();
        
        Email = email;
        NormalizedUserName = userName.ToUpper();
    }
}