using Academic.Core.Dtos;
using Academic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Academic.Core.Repositories.Interfaces;
using Academic.Core.Repositories;
using Newtonsoft.Json;

namespace Academic.Web.Controllers
{
    public class LoginController : Controller
    {
        IAuthenticationRepository _repository = new AuthenticationRepository();

        public ActionResult Index()
        {
            return View();
        }

       
       // POST: Login/Create
        [HttpPost]
        public async Task<ActionResult> Logar(UserDto userDto)
        {
           User user =  new User { Username= userDto.Username, Password=userDto.Password};
          var response = await _repository.Login(user);

            var cookie = new HttpCookie("usuario_logado");

            cookie.Value = response.Token;
            cookie.Expires = DateTime.Now.AddDays(7);
            cookie.HttpOnly = true;
            Response.Cookies.Add(cookie);

            return Redirect("/");

        }
    } }
