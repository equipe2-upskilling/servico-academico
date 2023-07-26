
using Academic.Domain;
using System.Threading.Tasks;

namespace Academic.Core
{
    public interface IAuthenticationRepository
    {
        Task<bool> CreateLogin(User user);
    }
}
