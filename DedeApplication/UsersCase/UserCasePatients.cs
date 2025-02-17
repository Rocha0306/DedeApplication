using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.Entities;
using DedeApplication.Interfaces;
using DedeApplication.UsersCase.Database;
using MongoDB.Driver.Linq;

namespace DedeApplication.UsersCase
{
    public class UserCasePatients : IUserCasePatients
    {

        private readonly UserCaseKeepData keepData; 
        public UserCasePatients(UserCaseKeepData _keepData)
        {
            keepData = _keepData; 
        }

        public PatientsEntity CreatePatients(PatientsEntity patients) {
              keepData.Patients.Add(patients);
              keepData.SaveChanges();
              return patients; 

                 
        } 

        public List<PatientsEntity> GetPatients(string HospitalName) {
            return keepData.Patients.Where(x => x.HospitalName.Equals(HospitalName)).ToList();

        
    }

        public PatientsEntity UpdatePatients(PatientsEntity patientsEntity) {
                keepData.Patients.Update(patientsEntity); 
                keepData.SaveChanges();
                return patientsEntity; 
        }

        public void DeletePatients(PatientsEntity patientsEntity) {
            keepData.Patients.Remove(patientsEntity);
            keepData.SaveChanges(); 
        }






}
}