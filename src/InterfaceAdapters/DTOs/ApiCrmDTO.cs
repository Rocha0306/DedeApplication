using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.DTOs;

namespace DedeApplication.UsersCase
{
    public record ApiCrmDTO(int code, string endereco_uf, string especialidade, string nome, string situacao, string primeira_inscricao_uf_data, List<ApiCrmDTO> data); 
}