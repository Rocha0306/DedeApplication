using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.DTOs;

namespace DedeApplication.Interfaces
{
    public interface ITokenService
    {
        public string GeneratorToken(string UserEntityRole); 

        public bool ValidatorToken(string UserToken); 
    }
}