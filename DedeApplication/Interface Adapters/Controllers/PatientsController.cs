using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DedeApplication.DTOs;
using DedeApplication.Entities;
using DedeApplication.Interfaces;
using DedeApplication.UsersCase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace DedeApplication.InterfaceAdapters.Controllers
{
    [Route("[controller]")]
    public class PatientsController : Controller
    {

        private readonly IAddPatients addPatients; 

        private readonly IRedisCache redis;

        private readonly IPatients patients; 

        private readonly IMapper mapper; 

        public PatientsController(IRedisCache IRedis, IMapper AutoMapper, IAddPatients add, IPatients _patients)
        {
           redis = IRedis;  
           mapper = AutoMapper; 
           addPatients = add;  
           patients = _patients;   
        }

          public Patients GetHospitalPatient(PatientsDTO patientsDTO) {
            string TokenKey = Request.Headers["Authorization"];
            string HospitalName = redis.GetFromCache(TokenKey); 
            patientsDTO.HospitalName = HospitalName;
            var Patients = new Patients();
            mapper.Map(patientsDTO, Patients); 
            return Patients; 
        }

       [HttpPost] 
       public ActionResult<Patients> GetPatients([FromBody] PatientsDTO patientsDTO) {
         var Patients = GetHospitalPatient(patientsDTO);
         return Ok(addPatients.CreatePatients(Patients)); 
        
         

       }
    }
}