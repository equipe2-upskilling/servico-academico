using Academic.Core.Dtos;
using Academic.Core.Repositories;
using Academic.Core.Repositories.Interfaces;
using Academic.Core.Services.Interfaces;
using Academic.Domain;
using System.Threading.Tasks;
namespace Academic.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository = new AuthenticationRepository();

        public AuthenticationService( ) { }

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
