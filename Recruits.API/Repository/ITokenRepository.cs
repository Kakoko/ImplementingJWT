using Recruits.API.Models;

namespace Recruits.API.Repository
{
    public interface ITokenRepository
    {
        Tokens Authenticate(Users users);
    }
}
