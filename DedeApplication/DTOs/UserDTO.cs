using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DedeApplication.DTOs
{
    public class UsersDTO
    {


    public string Id = Guid.NewGuid().ToString();

    [Required(ErrorMessage = "I need know your name")]
    public string Name {get;set;}
    
    [EmailAddress]
    [Required(ErrorMessage = "Email é obrigatorio")]
    public string Email {get;set;}

    public string CRM {get;set;}

    public string uf {get;set;}

    [Required(ErrorMessage = "Password is Required")]
    public string Password {get;set;}

    [Required(ErrorMessage = "Hey little brother what about the role")]
    public string Role {get;set;}

    [Required(ErrorMessage = "I need know the place")]
    public string HospitalName {get;set;}

    }
}