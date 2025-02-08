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

namespace DedeApplication.InterfaceAdapters.Controllers
{
    [ApiController]
    [Route("Users")]
    public class UsersController : Controller
    {
 
     

     private readonly IExternalApis consultasAPI; 


     private readonly IUserRegistration userRegistration; 

     private readonly IUsers UsersEntity;

     private readonly Users users;

     private readonly IMapper mapper; 



     public UsersController(IExternalApis consultas, IUserRegistration _userRegistration, IUsers _users, IMapper imapper, IUsers users2)
     {
        consultasAPI = consultas;
        userRegistration = _userRegistration; 
        UsersEntity = _users; 
        mapper = imapper; 

     }

        private DoctorDTO doctorInformation; 




      

        [HttpPost]
        public async Task<IActionResult> Registration([FromBody] UsersDTO usersDTO) {

            if(usersDTO.Role.Equals("Doctor")) {
            DoctorDTO doctorInformation = await consultasAPI.ValidateCRM(usersDTO.CRM, usersDTO.uf); 
            var Entity = mapper.Map(usersDTO, users); 
            var DoctorEntity = UsersEntity.DoctorRegistration(doctorInformation.DoctorExist, doctorInformation.DoctorName, Entity); 
            userRegistration.Registration(DoctorEntity);
            return Ok("Boa");
            
            }

            else {
                HunterApiDTO emailUser = await consultasAPI.ValidateEmail(usersDTO.Email); 
                var Users = mapper.Map(usersDTO, users);
                var SecretaryEntity = UsersEntity.SecretaryRegistration(emailUser.data.status, emailUser.data.result, emailUser.data.score, Users);
                userRegistration.Registration(SecretaryEntity);
                return Ok("Boa");
            }

    
                
    


        }
        

    


    }
}