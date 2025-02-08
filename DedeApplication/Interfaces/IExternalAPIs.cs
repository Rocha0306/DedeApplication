using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.DTOs;
using DedeApplication.UsersCase;

namespace DedeApplication.Interfaces
{
    public interface IExternalApis
    {
        public Task<DoctorDTO> ValidateCRM(string crm, string uf); 

        public Task<HunterApiDTO> ValidateEmail(string email); 
    }
}