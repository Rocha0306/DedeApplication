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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configura os serviços de controladores

var URI = builder.Configuration.GetValue<string>("URI");
var database = builder.Configuration.GetValue<string>("Database");
builder.Services.AddDbContext<KeepData>(Options => Options.UseMongoDB(URI, database));
builder.Services.AddSingleton<ITokenService, TokenService>();
builder.Services.AllDependencies();


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

// Mapeia controladores e endpoints
app.MapControllers();


app.Run();



