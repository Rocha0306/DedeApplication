using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.InterfaceAdapters.ExternalServices;

namespace DedeApplication.Interfaces
{
    public interface IRedisCache
    {

        public void PutInCache(string TokenKey, string Content); 

        public string GetFromCache(string TokenKey); 

        public void RemoveFromCache(string Key); 
        
    }
}