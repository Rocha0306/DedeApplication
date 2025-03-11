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

    [Required(ErrorMessage = "I need this field, its required - Name")]
    public string Name {get;set;}
    
    [EmailAddress]
    [Required(ErrorMessage = "I need this field, its required - Email")]
    public string Email {get;set;}

    [Required(ErrorMessage = "I need this field, its required - CRM")]
    public string CRM {get;set;}

     [Required(ErrorMessage = "I need this field, its required - UF")]
    public string uf {get;set;}

    [Required(ErrorMessage = "I need this field, its required - Password")]
    public string Password {get;set;}

    [Required(ErrorMessage = "I need this field, its required - Role")]
    public string Role {get;set;}

    [Required(ErrorMessage = "I need this field, its required - Birthdate")]
    public string BirthDate {get;set;}

    [Required(ErrorMessage = "I need this field, its required - VerifierDigit")]
    public string VerifierDigit {get;set;}

    [Required(ErrorMessage = "I need this field, its required - CPF")]
    public string CPF {get;set;}

    [Required(ErrorMessage = "I need this field, its required - CNPJ")]
    public string CNPJ {get;set;}

    [Required(ErrorMessage = "I need this field, its required - FirstYearAsDoctor")]
    public string FirstYearAsDoctor {get;set;} 

    }
}