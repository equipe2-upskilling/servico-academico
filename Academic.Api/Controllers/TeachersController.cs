using Academic.Core;
using Academic.Domain;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace Academic.Api.Controllers
{
    public class TeachersController : ApiController
    {

        private readonly ITeacherRepository _repository = new TeacherRepository();
        private readonly IAuthenticationService _authenticationService = new AuthenticationService();
        // GET api/values
        public IEnumerable<TeacherDto> Get()
        {
            return _repository.GetAll();
        }


        // GET api/values/5
        public TeacherDto Get(int id)
        {
            return _repository.Get(id);
        }

        // POST api/values
        public async Task PostAsync([FromBody] TeacherDto value)
        {

            
            UserDto user = new UserDto()
            {
                Username = value.Username,
                Password = value.Password
            };
            bool createResult = await _authenticationService.CreateLogin(user);

            if (createResult)
            {
                _repository.Add(value);
            }
            else
            {
                throw new Exception("Falha na criação de Login. Tente Novamente.");
            }

           
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] TeacherDto value)
        {
            _repository.Update(value, id);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            _repository.Delete( id);
        }
    }
}
