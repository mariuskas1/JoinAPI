using Microsoft.AspNetCore.Identity;

namespace Join.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
