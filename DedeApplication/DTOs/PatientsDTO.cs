using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DedeApplication.DTOs
{
        public class PatientsDTO {
            
        public string Id = Guid.NewGuid().ToString(); 
        public string Name {get; set;} 

        public string HospitalName {get;set;}
    }
}