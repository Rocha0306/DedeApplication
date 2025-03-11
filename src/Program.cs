using DedeApplication.Frameworks_Drivens;
using DedeApplication.UsersCase;
using DedeApplication.UsersCase.Database;
using DedeApplication.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using AutoMapper;
using DedeApplication.Entities;
using DedeApplication.DTOs;
using DedeApplication.InterfaceAdapters;
using DedeApplication.InterfaceAdapters.ExternalServices;
using Microsoft.AspNetCore.Http.Timeouts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configura os serviços de controladores

var URI = builder.Configuration.GetValue<string>("URI");
var database = builder.Configuration.GetValue<string>("Database");
builder.Services.AddDbContext<UserCaseKeepData>(Options => Options.UseMongoDB(URI, database));
builder.Services.AddSingleton<ITokenService, TokenService>();
builder.Services.AddScoped<Authorization>(); 
builder.Services.AllDependencies(); 
builder.Services.AddRequestTimeouts(options => {
    options.DefaultPolicy = new RequestTimeoutPolicy {
        Timeout = TimeSpan.FromMilliseconds(1000),
        TimeoutStatusCode = 503
    };
    options.AddPolicy("MyPolicy2", new RequestTimeoutPolicy {
        Timeout = TimeSpan.FromMilliseconds(1000),
        WriteTimeoutResponse = async (HttpContext context) => {
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync("Timeout from MyPolicy2!");
        }
    });
});


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware para roteamento
app.UseRouting();

// Middleware para autorizar (se necessário)
app.UseMiddleware<AuthMiddleware>();

app.UseMiddleware<ExceptionalHandler>();

app.UseAuthorization(); 

// Mapeia controladores e endpoints
app.MapControllers();


app.Run();



