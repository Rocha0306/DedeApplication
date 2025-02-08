using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.Entities;

namespace DedeApplication.Interfaces
{
    public interface ILogin
    {
        public Users Authentication(string CRMorEmail, string Password);
    }
}