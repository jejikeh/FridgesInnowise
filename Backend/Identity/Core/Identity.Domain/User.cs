using Microsoft.AspNetCore.Identity;

namespace Identity.Domain;

public sealed class User : IdentityUser<Guid>
{
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    
    public User(string userName, string email)
    {
        Id = new Guid();
        
        UserName = userName;
        NormalizedEmail = userName.ToUpper();
        
        Email = email;
        NormalizedUserName = userName.ToUpper();
    }

    public User(Guid id, string userName, string email) : this(userName, email)
    {
        Id = id;
        UserName = userName;
        NormalizedUserName = userName.ToUpper();
        Email = email;
        NormalizedEmail = email.ToUpper();
        EmailConfirmed = true;
        SecurityStamp = Guid.NewGuid().ToString("D");
        PhoneNumber = "+000000000000";
    }
}