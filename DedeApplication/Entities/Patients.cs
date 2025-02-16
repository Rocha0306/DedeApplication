using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.Interfaces;

namespace DedeApplication.Entities
{
    public class Patients : IPatients
    {
        public string Id {get;set;}
        public string Name {get;set;}
        public string HospitalName {get;set;} 
    }
}