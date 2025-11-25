using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace PlanShare.Infrastructure.Security.Tokens.Access;

internal abstract class JwtTokenHandler
{
    protected static SymmetricSecurityKey SecurityKey(string signingKey)
    {
        var symmetricKey = Encoding.UTF8.GetBytes(signingKey);
        return new SymmetricSecurityKey(symmetricKey);
    }
}