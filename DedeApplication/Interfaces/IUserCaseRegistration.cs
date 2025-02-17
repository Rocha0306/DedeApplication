using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.DTOs;
using DedeApplication.Entities;
using DedeApplication.UsersCase;

namespace DedeApplication.Interfaces
{
    public interface IUserCaseRegistration
    {
        public void Registration(UsersEntity users);
    
    }
}