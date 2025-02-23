using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DedeApplication.DTOs;
using DedeApplication.Entities;
using DedeApplication.Frameworks_Drivens;
using DedeApplication.Interfaces;
using DedeApplication.UsersCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace DedeApplication.InterfaceAdapters.Controllers
{
    [Route("[controller]")]
    public class PatientsController : Controller
    {

        private readonly IUserCasePatients UserCasePatients; 

        private readonly IRedisCache redis;

        private readonly IUserCaseRegistration patients; 

        private readonly IMapper mapper; 

        public PatientsController(IRedisCache IRedis, IMapper AutoMapper, IUserCasePatients add, IUserCaseRegistration _patients)
        {
           redis = IRedis;  
           mapper = AutoMapper; 
           UserCasePatients = add;  
           patients = _patients;   

        }


      
    
          public PatientsEntity GetHospitalPatientAndConvert(PatientsDTO patientsDTO) {
            string TokenKey = Request.Headers["Authorization"];
            string HospitalName = redis.GetFromCache(TokenKey); 
            patientsDTO.HospitalName = HospitalName;
            var Patients = new PatientsEntity();  
             mapper.Map(patientsDTO, Patients); 
            return Patients; 

         
        }

        public string GetHospitalName() {
          string TokenKey = Request.Headers["Authorization"];
          return redis.GetFromCache(TokenKey); 
        
        }

       [HttpPost] 
       public ActionResult<PatientsEntity> PostPatients([FromBody] PatientsDTO patientsDTO) {
         var Patients = GetHospitalPatientAndConvert(patientsDTO);
         Patients.Id = new Guid().ToString();
         return Ok(UserCasePatients.CreatePatients(Patients)); 
        
         

       }

       [HttpGet]
       public ActionResult<List<PatientsEntity>> GetPatients() {
          string HospitalName = GetHospitalName();
          return Ok(UserCasePatients.GetPatients(HospitalName)); 
         
          
       }


       [HttpPut]
       public ActionResult<PatientsEntity> UpdatePatients([FromBody] PatientsDTO patientsDTO) {
            var PatientsEntity = GetHospitalPatientAndConvert(patientsDTO); 
            var DataEdited = UserCasePatients.UpdatePatients(PatientsEntity); 
            return Ok(DataEdited); 
       }



       [HttpDelete]
       [Authorization]
       public ActionResult<PatientsEntity> DeletePatients([FromBody] PatientsDTO patientsDTO) {
            var PatientsEntity = GetHospitalPatientAndConvert(patientsDTO); 
            UserCasePatients.DeletePatients(PatientsEntity); 
            return Ok("The data was removed from database"); 
       }
    }
}