using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.DTOs;

namespace InterfaceAdapters.DTOs
{
    public record ApiCnpjDTO(string situacao_cadastral, List<ApiCnpjDTO> Data)
    {

    
        
    }
}