using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.Entities;

namespace DedeApplication.Interfaces
{
    public interface IUsersEntity
    {
         public UsersEntity DoctorRegistration(int DoctorExists, string ResponseApiName, UsersEntity users); 

          public UsersEntity SecretaryRegistration(string status, string result, int score, UsersEntity users);


          public void VerifyDuplicateUsers(UsersEntity user, UsersEntity userdatabase);

           public UsersEntity VerifyUser(UsersEntity user); //Login


    }
}