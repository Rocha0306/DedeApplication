using DedeApplication.Entities;
using DedeApplication.Interfaces;
using DedeApplication.UsersCase.Database;
using StackExchange.Redis;

namespace DedeApplication.UsersCase
{
    public class Login : ILogin
    {


        private readonly KeepData keepData; 

        private readonly IUsers UsersEntity; 

        public Login(KeepData _keepData, IUsers users)
        {
            keepData = _keepData; 
            UsersEntity = users;
        }

        Users ILogin.Authentication(string CRMorEmail, string Password)
        {
             
            
            var Users = keepData.Users.FirstOrDefault(x => x.CRM.Equals(CRMorEmail) || x.Email.Equals(CRMorEmail) && x.Password.Equals(Password));
            return UsersEntity.VerifyUser(Users);
            
        }
    }
}