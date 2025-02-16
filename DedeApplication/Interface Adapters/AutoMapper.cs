using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DedeApplication.DTOs;
using DedeApplication.Entities;
using DedeApplication.UsersCase;

namespace DedeApplication.Frameworks_Drivens
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<UsersDTO, Users>();
            CreateMap<DoctorDTO, UsersDTO>(); 
            CreateMap<PatientsDTO, Patients>();
        }
    }
}