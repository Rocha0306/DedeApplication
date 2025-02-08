using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DedeApplication.DTOs;
using DedeApplication.Interfaces;
using DedeApplication.UsersCase;
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

        public async Task<DoctorDTO>ValidateCRM(string crm, string uf)
        {
            string request = $"https://www.consultacrm.com.br/api/index.php?tipo=crm&destino=json&uf={uf}&q={crm}&chave=57a73dfde990483";
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            Uri uri = new Uri(request);
            httpRequestMessage.RequestUri = uri;
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            CancellationToken cancellationToken = new CancellationToken();
            var responseAPI = await httpResponseMessage.Content.ReadFromJsonAsync<ResponseApiCrmDTO>(cancellationToken); 
            var DoctorName = responseAPI.Item.FirstOrDefault().nome ?? "No Name"; 
            var doctorInformation = new DoctorDTO(responseAPI.Total, DoctorName);
            return doctorInformation; 
            //Cada instancia do controlador cria uma Lista única então em caso de multiplas requsiçoes 
            //não haverá um acumulo de dados nas Listas devido ao lifetime scoped
        }

        public async Task<HunterApiDTO> ValidateEmail(string email)
        {
            string request = $"https://api.hunter.io/v2/email-verifier?email={email}&api_key=9218837d07af1615522ee051fc78cac398c2e1c5"; 

            HttpClient httpClient = new HttpClient();
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            Uri uri = new Uri(request);
            httpRequestMessage.RequestUri = uri;
            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            CancellationToken cancellationToken = new CancellationToken();
            var ResponseApi = await httpResponseMessage.Content.ReadFromJsonAsync<HunterApiDTO>(cancellationToken);
            return ResponseApi;
                
        }
    }
}