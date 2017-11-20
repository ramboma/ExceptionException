﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Resources;
using System.Collections;
namespace YankResources
{
    public class Core
    {
        private ResourceSet _resourceSet; 
        public Core(string path)
        {
            Assembly assembly = Assembly.LoadFile(path);
            var list = assembly.GetManifestResourceNames();
            string resourceName = list.FirstOrDefault(s => s.EndsWith("resources"));
            if (string.IsNullOrEmpty(resourceName))
                Console.WriteLine(assembly.FullName + "没有资源文件或者资源文件名称不规范!");
            _resourceSet = new ResourceSet(assembly.GetManifestResourceStream(resourceName));
        }
        public string getValue(string key)
        {
            return (string)_resourceSet.GetObject(key);
        }
        public IDictionaryEnumerator getKeys()
        {
            return _resourceSet.GetEnumerator(); 
        }
    }
}
