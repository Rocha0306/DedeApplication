using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.DTOs;
using DedeApplication.UsersCase;
using InterfaceAdapters.DTOs;

namespace DedeApplication.Interfaces
{
    public interface IExternalApis
    {
        public Task<ApiCrmDTO> ValidateCRM(string crm, string uf); 

        public Task<ApiCpfDTO> ValidateCPF(string CPF, string birthdate); 

        public Task<ApiCnpjDTO> ValidateCNPJ(string CNPJ); 
    }
}