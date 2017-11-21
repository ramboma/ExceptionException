using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.MySql;
using System.Configuration;
namespace YankResources
{
    public class DataFactory
    {
        private static readonly DataFactory _instance = new DataFactory();
        private DataFactory() {
            var dbFactory = new OrmLiteConnectionFactory(ConfigurationManager.AppSettings["ConnectionString"],MySqlDialectProvider.Instance);
        }
        public static DataFactory getInstance()
        {
            return _instance; 
        }
    }
    
}
