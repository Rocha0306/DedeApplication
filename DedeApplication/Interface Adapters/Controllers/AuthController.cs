using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.DTOs;
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

        public AuthController(KeepData _mongoDbContext, ILogin _login, ITokenService _tokenService)
        {

            login = _login; 
            tokenService = _tokenService; 
            
        }
        


        public TokenDTO Login([FromBody] LoginDTO loginDTO) {
            var Users = login.Authentication(loginDTO.CRMorEmail, loginDTO.CRMorEmail);
            return tokenService.GeneratorToken(Users.HospitalName); 
            
        
        }      
    
    }
}