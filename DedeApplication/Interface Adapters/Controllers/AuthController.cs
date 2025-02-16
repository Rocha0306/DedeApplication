using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.DTOs;
using DedeApplication.InterfaceAdapters.ExternalServices;
using DedeApplication.Interfaces;
using DedeApplication.UsersCase.Database;
using Microsoft.AspNetCore.Mvc;

namespace DedeApplication.InterfaceAdapters.Controllers
{
    [ApiController]
    [Route("Auth")]
    public class AuthController : ControllerBase
    {

       

        private readonly ILogin login; 

        private readonly ITokenService tokenService;  

        private readonly IRedisCache rediscache; 

        public AuthController(KeepData _mongoDbContext, ILogin _login, ITokenService _tokenService, IRedisCache _rediscache)
        {

            login = _login; 
            tokenService = _tokenService; 
            rediscache = _rediscache;             
        }

        


        public ActionResult<TokenDTO> Login([FromBody] LoginDTO loginDTO) {
            var Users = login.Authentication(loginDTO.CRMorEmail, loginDTO.CRMorEmail);
            string Token = tokenService.GeneratorToken(); 
            rediscache.PutInCache(Token, Users.HospitalName);
            return new TokenDTO(Token);  

            
        
        }      
    
    }
}