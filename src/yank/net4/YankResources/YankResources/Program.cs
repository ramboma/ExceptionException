using System;
using System.Collections.Generic;
using System.Linq;
using YankResources.DTO;
using YankResources.BLL;

namespace YankResources
{
    class Program
    {
        static void Main(string[] args)
        {
            string netPath = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319";
            string netZhPath = netPath + @"\zh-Hans";
            //读取所有的默认dll
            var netList = System.IO.Directory.EnumerateFiles(netPath, "*.dll").ToList();
            var zhNetList = System.IO.Directory.EnumerateFiles(netZhPath, "*.dll").ToList();
            //建立映射关系
            var mapper = new List<ResourceManagerDTO>();
            foreach (var netfile in netList)
            {
                int lastEqu = netfile.LastIndexOf(@"\");
                string filename = netfile.Substring(lastEqu + 1);
                var noExtendFileName = filename.Remove(filename.Length - 4, 4);
                string resourceFileName = noExtendFileName + ".resources.dll";

                var zhfile = zhNetList.FirstOrDefault(s => s.IndexOf(resourceFileName)>0 );
                if (string.IsNullOrEmpty(zhfile))
                {
                    //todo:写入数据库
                    Console.WriteLine(netfile + "不存在资源文件!");
                    continue;
                }
                //读取语言包dll
                string netFilePath= netfile;
                string netZhFilePath=zhfile;

                Core core = new Core(netFilePath);
                Core coreZh = new Core(netZhFilePath);
                if (!core.IsValid | !coreZh.IsValid) continue;
                var  enumerator=core.getKeys();
                while(enumerator.MoveNext())
                {
                    var one = new ResourceManagerDTO();
                    one.ResourceKey= enumerator.Key.ToString();
                    one.ResourceValue = enumerator.Value.ToString();
                    one.ResourceZhValue = coreZh.getValue(one.ResourceKey);
                    one.AssemblyName = noExtendFileName;
                    one.AssemblyName = noExtendFileName;
                    one.AssemblyPath = netFilePath;
                    one.AssemblyZhPath = netZhFilePath;
                    mapper.Add(one);
                }
            }
            
            try
            {
                ResourceManagerBiz biz = new ResourceManagerBiz();
                biz.InsertAllResourceManager(mapper);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
            }
            Console.Read();
        }
    }
}
