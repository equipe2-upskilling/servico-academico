
using Academic.Domain;
using System.Threading.Tasks;

namespace Academic.Core.Repositories.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<bool> CreateLogin(User user);
        Task<AccessToken> Login(User user);
    }
}
