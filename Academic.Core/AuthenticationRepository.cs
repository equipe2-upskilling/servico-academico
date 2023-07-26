using Academic.Domain;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Core
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private static AccessToken accessToken;
        private static string _apiUrl;

        public AuthenticationRepository()
        {
            _apiUrl = "https://localhost:44379";
        }
        public async Task<bool> CreateLogin(User user)
        {
            var urlBase = _apiUrl + "/register";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.PostAsJsonAsync(urlBase, user);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro: {ex.Message}");
                }
                return false;
            }
        }
    }
}
