using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DedeApplication.InterfaceAdapters.Controllers
{
    [Route("[controller]")]
    public class PatientsController : Controller
    {

       [HttpGet] 
       public void GetPatients() {
        
       }
    }
}