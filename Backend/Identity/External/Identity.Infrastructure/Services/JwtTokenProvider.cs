using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Identity.Infrastructure.Common.Configuration;
using Identity.Infrastructure.Common.Configuration.Models;
using Identity.Persistence.Services;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Identity.Infrastructure.Services;

public class JwtTokenProvider(IIdentityInfrastructureConfiguration configuration) : IRandomAccessTokenProvider
{
    private readonly JwtTokenConfiguration _jwtTokenConfiguration = configuration.JwtTokenConfiguration;

    public string GenerateRandomToken(Guid userId, string email)
    {
        var claims = GetClaims(userId, email);
        var secretKey = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddSeconds(_jwtTokenConfiguration.ExpirationInSeconds),
            issuer: _jwtTokenConfiguration.Issuer,
            audience: _jwtTokenConfiguration.Audience,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtTokenConfiguration.Secret)),
                SecurityAlgorithms.HmacSha256Signature
            )
        );
        
        return new JwtSecurityTokenHandler().WriteToken(secretKey);
    }

    private static IEnumerable<Claim> GetClaims(Guid userId, string email)
    {
        return new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture))
        };
    }
}