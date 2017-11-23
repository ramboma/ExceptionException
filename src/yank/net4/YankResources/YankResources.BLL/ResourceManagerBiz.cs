using System.Collections.Generic;
using YankResources.DTO;
using YankResources.Entity;
using YankResources.DAL;
using EmitMapper;
namespace YankResources.BLL
{
    public class ResourceManagerBiz
    {
        private ResourceDAO dao;
        public ResourceManagerBiz()
        {
            dao = new ResourceDAO();
        }
        public void  InsertAllResourceManager(List<ResourceManagerDTO> list)
        {
            //验证
            
                var mapper = ObjectMapperManager.Instance.GetMapper<List<ResourceManagerDTO>, List<ResourceMapperEntity>>();
                var entityList = mapper.Map(list);
                dao.InsertAll(entityList);
           
                //异常处理

        }
        
    }
}
