
using Academic.Domain;
using System.Threading.Tasks;

namespace Academic.Core.Repositories.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<bool> CreateLogin(User user);
        Task<string> Login(User user);
    }
}
