using Identity.Domain;
using Identity.Persistence.Common.Configuration;
using Identity.Persistence.Common.Configuration.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Persistence.Services.ModelConfiguration;

public class SeedAdminUserConfiguration(IIdentityPersistenceConfiguration persistenceConfiguration) : IEntityTypeConfiguration<User>
{
    private readonly SeedDataConfiguration _dataConfiguration = persistenceConfiguration.SeedDataConfiguration; 
    
    public void Configure(EntityTypeBuilder<User> builder)
    {
        if (!_dataConfiguration.Seed)
        {
            return;
        }
        
        var user = new User(_dataConfiguration.AdminId, _dataConfiguration.AdminUserName, _dataConfiguration.AdminEmail);
        var passwordHasher = new PasswordHasher<User>();
        user.PasswordHash = passwordHasher.HashPassword(user, _dataConfiguration.AdminPassword);
        builder.HasData(user);
    }
}