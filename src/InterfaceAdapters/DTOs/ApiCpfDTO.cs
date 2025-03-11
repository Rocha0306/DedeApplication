using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterfaceAdapters.DTOs
{
    public record ApiCpfDTO(
    string NomeDaPf,
    string DataNascimento,
    string SituacaoCadastral,
    string DigitoVerificador, 
    List<ApiCnpjDTO> Data
);



}