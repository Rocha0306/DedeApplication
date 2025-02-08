using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.DTOs;
using DedeApplication.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DedeApplication.Entities
{
    public class Users : IUsers
    {
   
    public string Id { get; set; }
    public string Name {get;set;}
    public string Email { get; set; }
    public string CRM { get; set; }
    public string Uf { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string HospitalName { get; set; }


    public Users()
    {
    
    }

        

        public Users(string id, string name, string email, string role, string hospitalname, string password) 
    {
        //Secretaria

       this.Id = id; 
       this.Name = name; 
       this.Email = email; 
       this.Role = role; 
       this.HospitalName = hospitalname; 
       this.Password = password; 
        
    }

    public Users(string id, string name, string email, string crm, string uf, string password, string role, string hospitalname)
    {
            //Medico 

        this.Id = id;
        this.Name = name; 
        this.Email = email;
        this.CRM = crm;
        this.Uf = uf;
        this.Password = password;
        this.Role = role;
        this.HospitalName = hospitalname;
    }


    public Users DoctorRegistration(int DoctorExists, string ResponseApiName, Users users) {

        if(DoctorExists.Equals(0)) {
            throw new BadHttpRequestException("CRM not valid or this CRM is not in our data"); 
            //As vezes CRM é valido porém a API que utilizamos para consulta não encontra o médico
        }

        if(users.Password.Contains(users.Name) || users.Password.Contains(users.Email)) {
            throw new BadHttpRequestException("Your password cannot contain nothing related with you email or name");
        }

        if(!ResponseApiName.Equals(users.Name.ToUpper())) {
             throw new BadHttpRequestException("You are a fucking invasor");
        }

        
    
       return users; 
        

        


        


    } 



    public Users SecretaryRegistration(string status, string result, int score, Users users) {
        if(status.Equals("valid")) {
            if(result.Equals("deliverable")) {
                if(score > 85) {
                    return users; 
                }

                else {
                    throw new BadHttpRequestException("This email doesnt have enough score", 400);
                }

            }

            else {
                throw new BadHttpRequestException("This email is not deliverable", 400);
            }
        }

        else {
            throw new BadHttpRequestException("This email is not Valid", 400);
        }
        
    }


    public void VerifyDuplicateUsers(Users user, Users userdatabase) {

        if(user.Role.Equals("Doctor")) {
           if(userdatabase != null) {
             if(user.CRM.Equals(userdatabase.CRM)) {
                throw new BadHttpRequestException("This Users already exist", 400); 
            }
           }
        
        }

        if(user.Role.Equals("Secretary")) {
             if(user.Email.Equals(userdatabase.Email)) {
                throw new BadHttpRequestException("This Users already exist", 400); 
            }
        }
    }


    public Users VerifyUser(Users user) {
        if(user == null) {
            throw new BadHttpRequestException("You cant acess our assets because you dont have account", 403); 
        }

        return user; 


    }

    

    
    }
}