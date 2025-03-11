using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.Entities;

namespace DedeApplication.Interfaces
{
    public interface IUserCasePatients
    {
        public PatientsEntity CreatePatients(PatientsEntity patients); 

        public List<PatientsEntity> GetPatients(string HospitalName); 

        public PatientsEntity UpdatePatients(PatientsEntity patientsEntity); 

         public void DeletePatients(PatientsEntity patientsEntity); 
    }
}