using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DedeApplication.DTOs;
using DedeApplication.Interfaces;
using DedeApplication.UsersCase;
using InterfaceAdapters.DTOs;
using MongoDB.Bson;

namespace DedeApplication.UsersCase
{
    public class ExternalAPIs : IExternalApis
    {

         private readonly IMapper mapper;  

         public ExternalAPIs(IMapper _mapper)
         {
            mapper = _mapper; 
         }

    

        public async Task<ApiCrmDTO>ValidateCRM(string crm, string uf)
        {
            string request = $"https://api.infosimples.com/api/v2/consultas/cfm/cadastro?token=Q6B0qFasuwV7HBxgzpdxwRkH5blojgasMtpkvDYx&inscricao={crm}&uf={uf}&timeout=25";
            HttpClient httpClient = new HttpClient();
            Uri uri = new Uri(request);
            HttpMethod httpMethod = HttpMethod.Post; 
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, uri); 
            httpClient.Timeout = TimeSpan.FromSeconds(30); 
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage); 
            CancellationToken cancellationToken = new CancellationToken();
            var responseAPI = await httpResponseMessage.Content.ReadFromJsonAsync<ApiCrmDTO>(cancellationToken); 
            return responseAPI;
        }

         public async Task<ApiCpfDTO> ValidateCPF(string CPF, string birthdate)
        {
            string endpoint = $"https://api.infosimples.com/api/v2/consultas/receita-federal/cpf?token=Q6B0qFasuwV7HBxgzpdxwRkH5blojgasMtpkvDYx&cpf={CPF}&birthdate={birthdate}&origem=web";
            Uri uri = new Uri(endpoint); 
            HttpMethod httpMethod = new HttpMethod("GET"); 
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, endpoint);
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(); 
            httpResponseMessage = await httpClient.SendAsync(httpRequestMessage); 
            ApiCpfDTO apiCpfDTO = await httpResponseMessage.Content.ReadFromJsonAsync<ApiCpfDTO>();
            return apiCpfDTO;  
        }

        public async Task<ApiCnpjDTO> ValidateCNPJ(string CNPJ)
        {
            string endpoint = $"https://api.infosimples.com/api/v2/consultas/receita-federal/cnpj?token=Q6B0qFasuwV7HBxgzpdxwRkH5blojgasMtpkvDYx&cnpj={CNPJ}&mobile_sem_login=1";
            Uri uri = new Uri(endpoint); 
            HttpMethod httpMethod = new HttpMethod("GET"); 
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, endpoint);
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(); 
            httpResponseMessage = await httpClient.SendAsync(httpRequestMessage); 
            ApiCnpjDTO apicnpj = await httpResponseMessage.Content.ReadFromJsonAsync<ApiCnpjDTO>();
            return apicnpj;  
        }


        

    
    }
}