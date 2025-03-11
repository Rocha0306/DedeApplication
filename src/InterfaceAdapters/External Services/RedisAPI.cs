using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.Entities;
using DedeApplication.Interfaces;
using StackExchange.Redis;

namespace DedeApplication.InterfaceAdapters.ExternalServices
{
    public class RedisCache : IRedisCache
    {
        private readonly ConfigurationOptions AuthParams = new ConfigurationOptions {
            EndPoints={"redis-18221.c308.sa-east-1-1.ec2.redns.redis-cloud.com:18221"},
            User="default",
            Password="PeNpJuxe1CFhduTZX8id8LnS1CFfycUH"
        };

    

        public void PutInCache(string TokenKey, string Content) {
            var connectionMultiplexer = ConnectionMultiplexer.Connect(AuthParams);
            IDatabase RedisDatabase = connectionMultiplexer.GetDatabase();
            RedisDatabase.StringSet(TokenKey, Content);
             
        }

    
    
        public string GetFromCache(string Key) {
            ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(AuthParams);
            IDatabase RedisDatabase = connectionMultiplexer.GetDatabase(); 
            string Content = RedisDatabase.StringGet(Key); 
            if(Content == null) {
                throw new BadHttpRequestException("He is not in cache i cant continue", 500); 
            }
            
            return Content; 
        }

        public void RemoveFromCache(string Key) {
            ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(AuthParams);
            IDatabase RedisDatabase = connectionMultiplexer.GetDatabase(); 
            RedisDatabase.StringGetDelete(Key); 
        }
    }
}