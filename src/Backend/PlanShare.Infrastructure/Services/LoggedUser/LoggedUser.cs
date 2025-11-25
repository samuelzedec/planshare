using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using PlanShare.Domain.Entities;
using PlanShare.Domain.Security.Tokens;
using PlanShare.Domain.Services.LoggedUser;
using PlanShare.Infrastructure.DataAccess;

namespace PlanShare.Infrastructure.Services.LoggedUser;

internal sealed class LoggedUser(
    PlanShareDbContext dbContext,
    ITokenProvider tokenValue)
    : ILoggedUser
{
    public async Task<User> Get()
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = tokenHandler.ReadJwtToken(tokenValue.Value());
        var identifier = jwtSecurityToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.NameId).Value;

        return await dbContext
            .Users
            .AsNoTracking()
            .FirstAsync(user => user.Active && user.Id == Guid.Parse(identifier));
    }
}