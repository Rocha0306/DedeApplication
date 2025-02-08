using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.Entities;

namespace DedeApplication.Interfaces
{
    public interface IUsers
    {
         public Users DoctorRegistration(int DoctorExists, string ResponseApiName, Users users); 

          public Users SecretaryRegistration(string status, string result, int score, Users users);


          public void VerifyDuplicateUsers(Users user, Users userdatabase);

           public Users VerifyUser(Users user); //Login


    }
}