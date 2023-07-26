
using System.Configuration;


namespace Academic.Web.Models
{
    public class MyContext
    {

        public string ConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GamaApp"].ConnectionString;

            return connectionString;
        }
    }
}