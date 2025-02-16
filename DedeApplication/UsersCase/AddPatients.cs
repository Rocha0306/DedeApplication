using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.Entities;
using DedeApplication.Interfaces;
using DedeApplication.UsersCase.Database;

namespace DedeApplication.UsersCase
{
    public class AddPatients : IAddPatients
    {

        private readonly KeepData keepData; 
        public AddPatients(KeepData _keepData)
        {
            keepData = _keepData; 
        }

        public Patients CreatePatients(Patients patients) {
              keepData.Patients.Add(patients);
              return patients; 

                 
        } 
    }
}