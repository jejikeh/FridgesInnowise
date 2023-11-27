using Identity.Application.Common.Models.Tokens;
using Identity.Domain;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Persistence.Services.ModelConfiguration;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(token => token.Id);
        builder.HasIndex(token => token.Token).IsUnique();
        builder
            .HasOne(token => token.User)
            .WithMany(user => user.RefreshTokens)
            .HasForeignKey(token => token.UserId)
            .IsRequired();
    }
}