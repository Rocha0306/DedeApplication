using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using DedeApplication.Entities;
using DedeApplication.Interfaces;
using Org.BouncyCastle.Tls;

namespace DedeApplication.InterfaceAdaptersExternalServices

{

    public class EmailSender : IEmailSender
    {
        public string SendEmail(string PersonReceiver) {
                SmtpClient smtpClient = new SmtpClient(); 
                smtpClient.Host = "smtp.gmail.com"; 
                smtpClient.Port = 587; 
                smtpClient.UseDefaultCredentials = false; 
                NetworkCredential MyCredentials = new NetworkCredential("dedeApplication@gmail.com", "hzou ejug fmqn sunp"); 
               smtpClient.Credentials = MyCredentials; 
                smtpClient.EnableSsl = true; 
                string From = "DedeApplication@gmail.com";
                Random random = new Random(); 
                long Number = random.NextInt64();
                string BodyNumberAuth = Number.ToString(); 
                string Subject = "Email Authentication DedeApplication"; 
                MailMessage mailMessage = new MailMessage(From, PersonReceiver, Subject, BodyNumberAuth);
                smtpClient.Send(mailMessage); 
                return BodyNumberAuth; 
        }
    }

}
