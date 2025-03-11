using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.DTOs;
using DedeApplication.InterfaceAdapters.ExternalServices;
using DedeApplication.InterfaceAdaptersExternalServices;
using DedeApplication.Interfaces;
using DedeApplication.UsersCase.Database;
using Microsoft.AspNetCore.Mvc;

namespace DedeApplication.InterfaceAdapters.Controllers
{
    [ApiController]
    [Route("Auth")]
    public class AuthController : ControllerBase
    {

       

        private readonly IUserCaseLogin login; 

        private readonly ITokenService tokenService;  

        private readonly IRedisCache rediscache; 

        public AuthController(UserCaseKeepData _mongoDbContext, IUserCaseLogin _login, ITokenService _tokenService, IRedisCache _rediscache)
        {

            login = _login; 
            tokenService = _tokenService; 
            rediscache = _rediscache;             
        }


        

        

        [HttpPost]
        public ActionResult<TokenDTO> Login([FromBody] LoginDTO loginDTO) {
            var Users = login.Authentication(loginDTO.CRMorEmail, loginDTO.CRMorEmail);
            string Token = tokenService.GeneratorToken(Users.Role); 
            rediscache.PutInCache(Token, "Users.HospitalName");
            return new TokenDTO(Token);  

            
        
        }   

        [HttpDelete]
        public ActionResult Logout() {
            string Token = Request.Headers["Authorization"]; 
            if(Token == null) {
                return BadRequest("No token, wtf?");
            }

            rediscache.RemoveFromCache(Token); 
            return Ok(); 

            

            
        }  
    
    }
}