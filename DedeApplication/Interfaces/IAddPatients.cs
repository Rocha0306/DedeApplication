using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.Entities;

namespace DedeApplication.Interfaces
{
    public interface IAddPatients
    {
        public Patients CreatePatients(Patients patients); 
    }
}