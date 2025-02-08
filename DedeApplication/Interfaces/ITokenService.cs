using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.DTOs;

namespace DedeApplication.Interfaces
{
    public interface ITokenService
    {
        public TokenDTO GeneratorToken(string HospitalName); 

        public bool ValidatorToken(string UserToken); 
    }
}