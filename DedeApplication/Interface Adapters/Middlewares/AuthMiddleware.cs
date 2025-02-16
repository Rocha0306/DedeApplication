using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DedeApplication.Frameworks_Drivens;
using DedeApplication.Interfaces;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NRedisStack.Graph;
using StackExchange.Redis;

namespace DedeApplication.UsersCase
{
public class AuthMiddleware {
 
    private readonly RequestDelegate _next;

    private readonly ITokenService _tokenService; 

    public AuthMiddleware(RequestDelegate next, ITokenService tokenService)
    {
        _next = next;
        _tokenService = tokenService; 
       
    }

    public async Task Invoke(HttpContext context)
    {
        
    
        string endpointRequest = context.Request.GetDisplayUrl();
       
      if(endpointRequest != "http://localhost:8080/Auth" && endpointRequest != "http://localhost:8080/Users") {
        var UserToken = context.Request.Headers.Authorization;
        var Token = _tokenService.ValidatorToken(UserToken);

        if(Token == true) {
            await _next(context);
        }

        else {
            throw new BadHttpRequestException("Invalid Token"); 
        }

       }

    

        else {
            await _next(context);
        }








       

    }








    


}




}