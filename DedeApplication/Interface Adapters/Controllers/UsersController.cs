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

    
            DoctorDTO doctorInformation = await consultasAPI.ValidateCRM(usersDTO.CRM, usersDTO.uf); 
            var Entity = mapper.Map(usersDTO, users); 
            var DoctorEntity = UsersEntity.DoctorRegistration(doctorInformation.DoctorExist, doctorInformation.DoctorName, Entity);  
            string AuthNumber = emailSender.SendEmail(DoctorEntity.Email); 
            redisCache.PutInCache(AuthNumber, DoctorEntity.ToJson());
            return Ok("Good");
            
            }
 

        



        
    
                
    


        }
        

    


    }