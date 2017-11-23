using System.Collections.Generic;
using ServiceStack.OrmLite;
using YankResources.Entity;
using ServiceStack.OrmLite.MySql;
using System.Data;
namespace YankResources.DAL
{
    public class ResourceDAO
    {
        private OrmLiteConnectionFactory _factory = null;
        private IDbConnection _connection = null;
        public ResourceDAO()
        {
            _factory= new OrmLiteConnectionFactory(OrmHelper.getSqlConnection(), MySqlDialectProvider.Instance);
            _connection = _factory.Open();
        }
        public void InsertAll(List<ResourceMapperEntity> list)
        {
                bool bCreate = _connection.CreateTableIfNotExists<ResourceMapperEntity>();
                _connection.InsertAll<ResourceMapperEntity>(list);
        }
    }
}
