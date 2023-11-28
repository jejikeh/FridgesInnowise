using System.Text;
using Identity.Infrastructure.Common.Configuration.Models;
using Identity.Infrastructure.Services;
using Identity.Persistence.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Infrastructure.Common.Configuration.Injections;

internal static class JwtTokenProviderInjection
{
    internal static IServiceCollection UseJwtTokenProvider(this IServiceCollection services, JwtTokenConfiguration tokenGenerationConfiguration)
    {
        services
            .AddSingleton<IRandomAccessTokenProvider, JwtTokenProvider>()
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateActor = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    RequireExpirationTime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenGenerationConfiguration.Issuer,
                    ValidAudience = tokenGenerationConfiguration.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenGenerationConfiguration.Secret)),
                    ClockSkew = TimeSpan.Zero
                };
            });

        return services;
    }
}