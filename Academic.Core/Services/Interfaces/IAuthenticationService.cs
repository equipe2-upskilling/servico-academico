using Academic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Core.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> CreateLogin(UserDto userDto);
    }
}
