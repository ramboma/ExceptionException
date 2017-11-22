using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using YankResources.Utility.Warpper;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.MySql;
using System.Data;
namespace YankResources.Utility.Helper
{
    public class OrmHelper
    {
        private readonly static string _ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        private static IDbTransaction _transaction = null;
        public static bool CreateTableIfNotExists<T>()
        {
            bool b = false;
            OrmliteWrapper wrap = new OrmliteWrapper();
            using (var connector = wrap.getMysqlConnection(_ConnectionString))
            {
                b=connector.CreateTableIfNotExists<T>();
            }
            return b;
        }

        public static void InsertAll<T>(List<T> entityList)
        {
            OrmliteWrapper wrap = new OrmliteWrapper();
            using (var connector = wrap.getMysqlConnection(_ConnectionString))
            {
                 connector.InsertAll<T>(entityList);
            }
        }

        public static void BeginTranslation()
        {
            OrmliteWrapper wrap = new OrmliteWrapper();
            var connector = wrap.getMysqlConnection(_ConnectionString);
            _transaction = connector.BeginTransaction();
        }

        public static void Commit()
        {
            _transaction.Commit();
        }

        public static void Rollback()
        {
            _transaction.Rollback(); 
        }
    }
}
