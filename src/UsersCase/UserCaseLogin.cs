using DedeApplication.Entities;
using DedeApplication.Interfaces;
using DedeApplication.UsersCase.Database;
using StackExchange.Redis;

namespace DedeApplication.UsersCase
{
    public class UserCaseLogin : IUserCaseLogin
    {


        private readonly UserCaseKeepData keepData; 

        private readonly IUsersEntity UsersEntity; 

        public UserCaseLogin(UserCaseKeepData _keepData, IUsersEntity users)
        {
            keepData = _keepData; 
            UsersEntity = users;
        }

        UsersEntity IUserCaseLogin.Authentication(string CRMorEmail, string Password)
        {
             
            
            var Users = keepData.Users.FirstOrDefault(x => x.CRM.Equals(CRMorEmail) || x.Email.Equals(CRMorEmail) && x.Password.Equals(Password));
            return UsersEntity.VerifyUser(Users);
            
        }
    }
}