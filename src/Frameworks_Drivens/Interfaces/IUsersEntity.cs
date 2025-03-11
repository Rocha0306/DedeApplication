using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.DTOs;
using DedeApplication.Entities;
using DedeApplication.UsersCase;

namespace DedeApplication.Interfaces
{
    public interface IUsersEntity
    {
         
         
            public ApiCrmDTO VerifyDoctor(ApiCrmDTO responseCRM, UsersDTO usersDTO); 


          public void VerifyDuplicateUsers(UsersEntity user, UsersEntity userdatabase);

           public UsersEntity VerifyUser(UsersEntity user); //Login


    }
}