using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DedeApplication.Interfaces
{
    public interface IEmailSender
    {
        public string SendEmail(string PersonReceiver); 
    }
}