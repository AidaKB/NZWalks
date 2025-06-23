using Microsoft.AspNetCore.Identity;

namespace NZWalks.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTTokens(IdentityUser user, List<string> roles);
    }
}
