using Academic.Core.Dtos;
using Academic.Core.Repositories.Interfaces;
using Academic.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web;

namespace Academic.Core.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly string _apiUrl = "https://localhost:7215";


        public async Task<IEnumerable<TeacherCourseDto>> GetAllbyTeacher(int id)
        {
            var urlBase = _apiUrl + "/teacherId?teacherId="+id;
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseCookies = true;

            using (HttpClient client = new HttpClient(handler))
            {
                try
                {


                    var response = await client.GetAsync(urlBase);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var x = response.Content.ReadAsStringAsync().Result;
                        var y = JsonConvert.DeserializeObject<IEnumerable<TeacherCourseDto>>(x);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro: {ex.Message}");
                }
                return null;
            }
        }
    }
}
