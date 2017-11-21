using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.DataAnnotations;
namespace YankResources.Entity
{
        [Alias("ResourceMapper")]
        public class ResourceMapperEntity
        {
            [AutoIncrement]
            public int ResourceId { get; set; }
            public string ResourceKey { get; set; }
            [StringLength(2000)]
            public string ResourceValue { get; set; }
            [StringLength(2000)]
            public string ResourceZhValue { get; set; }
            public string AssemblyName { get; set; }
            [StringLength(2000)]
            public string AssemblyPath { get; set; }
            [StringLength(2000)]
            public string AssemblyZhPath { get; set; }
        }
}
