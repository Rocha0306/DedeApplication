using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.DTOs;

namespace DedeApplication.UsersCase
{
    public class ResponseApiCrmDTO
    {


    public int Total {get;set;}    
  
    
    public string nome {get;set;}



    public List<ResponseApiCrmDTO> Item {get;set;}
 

    }
}