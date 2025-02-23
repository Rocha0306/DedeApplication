using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DedeApplication.Frameworks_Drivens
{


    public class Authorization : Attribute, IAuthorizationFilter 
    {

    
            public void OnAuthorization(AuthorizationFilterContext authorizationFilterContext) {

           
                var Token = authorizationFilterContext.HttpContext.Request.Headers["Authorization"]; 
                JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler(); 
                JwtSecurityToken jwtSecurityToken = jwtSecurityTokenHandler.ReadJwtToken(Token); 
                var Role = jwtSecurityToken.Claims.First().ToString().Substring(6);

                if(!Role.Equals("Doctor")) {
                    throw new BadHttpRequestException("You dont have permissions to do this", 403);
                }


                } 

                

            

            }

        }
    