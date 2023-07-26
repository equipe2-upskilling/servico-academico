
using System.Configuration;


namespace Academic.Core.Repositories
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