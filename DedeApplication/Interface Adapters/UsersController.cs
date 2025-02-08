using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.DTOs;
using DedeApplication.FrameworksDrivens;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DedeApplication.InterfaceAdapters
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
 
       public readonly MongoDbContext mongoDbContext;

       public UsersController(MongoDbContext _mongoDbContext) {
        mongoDbContext = _mongoDbContext; 
    }

        [HttpPost]
        public string CreateUser([FromBody] UsersDTO usersDTO) {
            mongoDbContext.Users.AddAsync(usersDTO); 
            mongoDbContext.SaveChangesAsync();
            return "deu? Ve o banco";   
        }
    }
}