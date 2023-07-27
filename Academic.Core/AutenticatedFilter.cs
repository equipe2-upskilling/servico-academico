using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Xml.Linq;
using Academic.Core;
using Academic.Core.Dtos;
using Newtonsoft.Json;
using System.Runtime.Remoting.Contexts;
using System.Configuration;

namespace Academic.Core
{
    public class AutenticatedFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var cookie = filterContext.HttpContext.Request.Cookies["usuario_logado"];
    
            if (cookie != null)
            {
                try
                {

                      {
                        string token = cookie.Value.Trim('"');
                        var validationUrl = "https://localhost:7194/valid-token";

                        var httpClient = new HttpClient();

                        // Fazer a chamada HEAD
                        var request = new HttpRequestMessage(HttpMethod.Head, validationUrl);
                        request.Headers.Add("Authorization", $"Bearer {token}");
                        var response = httpClient.SendAsync(request).Result;
                        if (!response.IsSuccessStatusCode)
                        {
                            filterContext.Result = new HttpUnauthorizedResult();
                        }
                    }
                }
                catch
                {
                    filterContext.Result = new HttpUnauthorizedResult();
                }

            }
            else
            {
                // O cookie de autenticação não está presente, redirecione para a página de login
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result is HttpUnauthorizedResult)
            {
                // O usuário não está autenticado, redirecione para a página de login
                filterContext.Result = new RedirectResult("~/Login");
            }
        }
    }
}
