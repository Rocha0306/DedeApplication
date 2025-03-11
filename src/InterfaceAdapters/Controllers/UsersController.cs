using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.DTOs;
using DedeApplication.Frameworks_Drivens;
using DedeApplication.UsersCase.Database;
using DedeApplication.Interfaces;
using DedeApplication.UsersCase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DedeApplication.Entities;
using AutoMapper;
using MongoDB.Bson;
using Microsoft.AspNetCore.Http.Timeouts;
using Org.BouncyCastle.Asn1.Cmp;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Runtime.ExceptionServices;

namespace DedeApplication.InterfaceAdapters.Controllers
{
    [ApiController]
    [Route("Users")]
    public class UsersController : Controller
    {
 
     

     private readonly IExternalApis consultasAPI; 


     private readonly IUserCaseRegistration userRegistration; 

     private readonly IUsersEntity UsersEntity;

     private readonly UsersEntity users;

     private readonly IMapper mapper; 

     private readonly IRedisCache redisCache;

     private readonly IEmailSender emailSender; 



     public UsersController(IExternalApis consultas, IUserCaseRegistration _userRegistration, IUsersEntity _users, IMapper imapper, IUsersEntity users2, IRedisCache _redisCache, IEmailSender _emailSender)
     {
        consultasAPI = consultas;
        userRegistration = _userRegistration; 
        UsersEntity = _users; 
        mapper = imapper;
        redisCache = _redisCache;  
        emailSender = _emailSender; 

     }

        private DoctorDTO doctorInformation; 




      

        [HttpPost]
        public async Task<IActionResult> Registration([FromBody] UsersDTO usersDTO) {

    
            var responseApiCRM = await consultasAPI.ValidateCRM(usersDTO.CRM, usersDTO.uf);
            var responseApiCPF = await consultasAPI.ValidateCPF(usersDTO.CPF, usersDTO.BirthDate); 

            
            return Ok("good"); 

        



        
    
                
    


        }
        

    


    }
}