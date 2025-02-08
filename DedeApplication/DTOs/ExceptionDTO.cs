using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DedeApplication.DTOs
{
    public class ExceptionDTO
    {
        public int StatusCode {get;set;}

        public string Message {get;set;}

        public string StackTrace {get;set;}
    }
}