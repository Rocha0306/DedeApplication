using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DedeApplication.DTOs
{
    public record LoginDTO(

   [Required(ErrorMessage = "CRM or email are necessary")]     
   string CRMorEmail,       
    
    
    [Required(ErrorMessage = "Hey")]
    string Password
    
    );
}