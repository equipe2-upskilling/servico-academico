using Academic.Domain;
using Academic.Web.Models;
using System.Threading.Tasks;
namespace Academic.Core
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;


        public AuthenticationService(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;

        }

        public async Task<bool> CreateLogin(UserDto userDto)
        {
            User user = new User{ Username = userDto.Username, Password = userDto.Password };
            var result = await _authenticationRepository.CreateLogin(user);
            if(result)
            {
                return true;
            }
            return false;
        }
    }
}
