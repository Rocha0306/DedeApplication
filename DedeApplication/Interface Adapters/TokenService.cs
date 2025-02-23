using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DedeApplication.DTOs;
using DedeApplication.InterfaceAdapters.ExternalServices;
using DedeApplication.Interfaces;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using StackExchange.Redis;

namespace DedeApplication.Frameworks_Drivens
{
    public class TokenService : ITokenService
    {

        private JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        private JwtSecurityToken securityToken = new JwtSecurityToken();

      

       

        public string GeneratorToken(string UserEntityRole)
        {
            string TokenKey = "571e5851c09f813ec390b91790c0f276ebafacdf789012914a006992f29278c1"; 
            string Issuer = "Auth"; //Conteudo do Token - Issuer
            string Audience = "Client"; //Quem consome o token
           var claimsIdentity = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Role, UserEntityRole), // Definindo a role do usuário

        });

            DateTime Expires = DateTime.Now.AddMinutes(10); //Date Time - Expiration - Expiração do Token
            DateTime NotBefore = DateTime.Now.AddMilliseconds(1); //NotBefore - Tempo que o token não é considerado 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenKey));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            securityToken = jwtSecurityTokenHandler.CreateJwtSecurityToken(Issuer, Audience, claimsIdentity, NotBefore, Expires, null, signingCredentials);
            return jwtSecurityTokenHandler.WriteToken(securityToken); 

        }

        public bool ValidatorToken(string UserToken)
        {
        JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();     
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("571e5851c09f813ec390b91790c0f276ebafacdf789012914a006992f29278c1"));   
            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters {
                ValidateIssuer = true,
                ValidIssuer = "Auth",
                ValidateAudience = true,
                ValidAudience = "Client",
                IssuerSigningKey = key
            };
            Task<TokenValidationResult> tokenValidationResult = jwtSecurityTokenHandler.ValidateTokenAsync(UserToken, tokenValidationParameters);
            bool Result = tokenValidationResult.Result.IsValid; 
            return Result; 
        }

       
    }
}