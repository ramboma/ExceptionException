using System.Configuration;
namespace YankResources.DAL
{
    public class OrmHelper
    {
        private readonly static string _ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        public static string getSqlConnection()
        {
            return _ConnectionString;
        }
    }
}
