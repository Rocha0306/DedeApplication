using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.DTOs;
using DedeApplication.UsersCase;
using DedeApplication.UsersCase.Database;
using DedeApplication.Interfaces;
using DedeApplication.UsersCase;
using Microsoft.Extensions.DependencyInjection.Extensions;
using DedeApplication.Entities;
using AutoMapper;
using DedeApplication.InterfaceAdapters.ExternalServices;

namespace DedeApplication.Frameworks_Drivens
{     
    
    public static class DependecyInjection
    { 
        public static IServiceCollection AllDependencies(this IServiceCollection Services) {
                Services.AddSingleton<ITokenService, TokenService>();
                Services.AddScoped<IExternalApis, ExternalAPIs>();
                Services.AddScoped<IUserRegistration, UserRegistration>();
                Services.AddScoped<IUsers, Users>();
                Services.AddScoped<ILogin, Login>();
                Services.AddScoped<IRedisCache, RedisCache>(); 
                return Services;

        }
    }
}