using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.Interfaces;

namespace DedeApplication.UsersCase
{
    public class DoctorDTO
    {
    

    
        public DoctorDTO(int doctorexist, string doctorname) {
            this.DoctorExist = doctorexist;
            this.DoctorName = doctorname; 
        }

        public int DoctorExist {get;set;}

       

        public string DoctorName {get;} 


    
    }
}