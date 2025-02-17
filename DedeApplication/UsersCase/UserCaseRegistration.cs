using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.Entities;
using DedeApplication.UsersCase;
using DedeApplication.Interfaces;
using DedeApplication.UsersCase.Database;
using DedeApplication.DTOs;

namespace DedeApplication.UsersCase
{
    public class UserCaseRegistration : IUserCaseRegistration
    {

        private readonly UserCaseKeepData keepData; 

        private readonly IUsersEntity UsersEntity; 

        public UserCaseRegistration(UserCaseKeepData _keepData, IUsersEntity users)
        {
            keepData = _keepData; 
            UsersEntity = users;
        }

        public void Registration(UsersEntity users)
        {
            if(users.Role.Equals("Doctor")) {
                var UsersDatabase = keepData.Users.FirstOrDefault(x => x.CRM.Equals(users.CRM));
                UsersEntity.VerifyDuplicateUsers(users, UsersDatabase);
            }

            else {
                var UsersDatabase = keepData.Users.FirstOrDefault(x => x.Email.Equals(users.Email));
                UsersEntity.VerifyDuplicateUsers(users, UsersDatabase);
            }
            
            
            keepData.Add(users); 
            keepData.SaveChanges();
        }
    }
}