using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.MySql;
using System.Data;
namespace YankResources.Utility.Warpper
{
    public class OrmliteWrapper
    {
        public IDbConnection getMysqlConnection(string connectionString)
        {
            var dbFactory = new OrmLiteConnectionFactory(connectionString, MySqlDialectProvider.Instance);
            return dbFactory.Open();
        }
    }
}
