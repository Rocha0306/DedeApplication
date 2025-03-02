using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using DedeApplication.Entities;
using DedeApplication.InterfaceAdapters.ExternalServices;
using DedeApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Bson.IO;

namespace DedeApplication.InterfaceAdapters.Controllers
{
    [Route("[controller]")]
    public class VerificationController(IRedisCache _redis, IUserCaseRegistration _userCaseRegistration, IMapper _mapper, IUsersEntity usersEntity) : Controller
    {
        //Construtor primario

        private readonly IRedisCache redisCache = _redis;

        private readonly IUserCaseRegistration userCaseRegistration = _userCaseRegistration; 

        private readonly IMapper mapper = _mapper; 

        private readonly IUsersEntity users = usersEntity; 

        [HttpPost]
        public ActionResult ValidateUser([FromHeader] string VerificationEmailNumber) {
                string StringJsonUserEntity = redisCache.GetFromCache(VerificationEmailNumber);
                var UsersEntity = JsonSerializer.Deserialize<UsersEntity>(StringJsonUserEntity);
                userCaseRegistration.Registration(UsersEntity);
                return Ok(); 
        }

      

        
       
    }
}