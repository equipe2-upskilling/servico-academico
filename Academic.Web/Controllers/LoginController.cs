using Academic.Core.Dtos;
using Academic.Domain;
using System;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Academic.Core.Services.Interfaces;
using Academic.Core.Services;
using Academic.Web.ModelView;
using Newtonsoft.Json;
using System.Web.Helpers;
using Academic.Core;

namespace Academic.Web.Controllers
{
    public class LoginController : Controller
    {
        IAuthenticationService _service = new AuthenticationService();

        public ActionResult Index(bool invalid = false)
        {
            return View(new { invalid = invalid });
        }


        // POST: Login/Create
        [HttpPost]
        public async Task<ActionResult> Logar(UserDto userDto)
        {
            if (userDto == null || string.IsNullOrEmpty(userDto.Username) || string.IsNullOrEmpty(userDto.Password))
                return View("Index", new ErrorModelView { Mensagem = "Login ou senha inválida" });

            var response = await _service.Login(userDto);

            if (response != null)
            {
                var cookie = new HttpCookie("usuario_logado");
      

                cookie.Value = JsonConvert.SerializeObject(response.Token);
                cookie.Expires = DateTime.Now.AddDays(7);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "TeacherCourse");
            }
            return RedirectToAction("Index", "TeacherCourse", new { isvalid = true});

        }

    }
}
