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
        private readonly ConfigurationOptions configurationOptions = new ConfigurationOptions {
            EndPoints = {"memcached-13693.c80.us-east-1-2.ec2.redns.redis-cloud.com:13693"},  
            User = "mc-e0j92", 
            Password = "YRo0HC71AY0J0SCEBkBuaDAyJaLIu8uJ"
        };

        public void PutInCache(string TokenKey, string HospitalName) {
            ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(configurationOptions);
            IDatabase RedisDatabase = connectionMultiplexer.GetDatabase(); 
            RedisDatabase.StringSet(TokenKey, HospitalName); 
             
        }
    
        public string GetFromCache(string TokenKey) {
            ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(configurationOptions);
            IDatabase RedisDatabase = connectionMultiplexer.GetDatabase(); 
            string HospitalName = RedisDatabase.StringGet(TokenKey); 
            return HospitalName; 
        }
    }
}