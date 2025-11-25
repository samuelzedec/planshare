using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using PlanShare.Domain.Security.Tokens;

namespace PlanShare.Infrastructure.Security.Tokens.Access.Validator;

internal sealed class JwtTokenValidator(string signingKey)
    : JwtTokenHandler, IAccessTokenValidator
{
    public Guid GetAccessTokenIdentifier(string token)
    {
        var identifier = GetClaimValue(token, JwtRegisteredClaimNames.Jti);
        return Guid.Parse(identifier);
    }

    public Guid GetUserIdentifier(string token)
    {
        var identifier = GetClaimValue(token, JwtRegisteredClaimNames.NameId);
        return Guid.Parse(identifier);
    }

    public void Validate(string token)
    {
        var validationParameters = new TokenValidationParameters()
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            IssuerSigningKey = SecurityKey(signingKey),
            ClockSkew = new TimeSpan(0)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        tokenHandler.ValidateToken(token, validationParameters, out _);
    }

    private static string GetClaimValue(string token, string claimType)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(token);
        return jwtToken.Claims.First(claim => claim.Type == claimType).Value;
    }
}