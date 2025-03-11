using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.DTOs;
using DedeApplication.Interfaces;
using DedeApplication.UsersCase;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DedeApplication.Entities
{
    public class UsersEntity : IUsersEntity
    {
   
    public string Id { get; set; }
    public string Name {get;set;}
    public string Email { get; set; }
    public string CRM { get; set; }
    public string Uf { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }


    public UsersEntity()
    {
    
    }

        

        public UsersEntity(string id, string name, string email, string role, string password) 
    {
        //Secretaria

       this.Id = id; 
       this.Name = name; 
       this.Email = email; 
       this.Role = role;
       this.Password = password; 
        
    }

    public UsersEntity(string id, string name, string email, string crm, string uf, string password, string role)
    {
            //Medico 

        this.Id = id;
        this.Name = name; 
        this.Email = email;
        this.CRM = crm;
        this.Uf = uf;
        this.Password = password;
        this.Role = role;
    }


    public ApiCrmDTO VerifyDoctor(ApiCrmDTO responseCRM, UsersDTO usersDTO) {
        return responseCRM; 
    }


    private void VerifyCRM(ApiCrmDTO CrmDTO, UsersDTO usersDTO) {

        switch(CrmDTO.code) {
            case 612:
            throw new HttpRequestException("CRM not found, this is rare you cant use");
            case 605:
            throw new HttpRequestException("CRM not found, timeout"); 
            case 607:
            throw new HttpRequestException("CRM or uf invalid"); 

        }


        if(!CrmDTO.situacao.Equals("Regular")) {
            throw new HttpRequestException("This doctor dont have a regular situation probably he is retired or dead");
        }

        


    }

    private void VerifyCPF() {

    }


    private void VerifyCNPJ() {

    }





    public void VerifyDuplicateUsers(UsersEntity user, UsersEntity userdatabase) {

        if(user.Role.Equals("Doctor")) {
           if(userdatabase != null) {
             if(user.CRM.Equals(userdatabase.CRM)) {
                throw new BadHttpRequestException("This Users already exist", 400); 
            }
           }
        
        }

    }


    public UsersEntity VerifyUser(UsersEntity user) {
        if(user == null) {
            throw new BadHttpRequestException("You cant acess our assets because you dont have account", 403); 
        }

        return user; 


    }

    

    
    }
}