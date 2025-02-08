using DedeApplication.FrameworksDrivens;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configura os serviços de controladores
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<MongoDbContext>();

var URI = builder.Configuration.GetValue<string>("URI");
var database = builder.Configuration.GetValue<string>("Database");

builder.Services.AddDbContext<MongoDbContext>(Options => Options.UseMongoDB(URI, database));
builder.Services.AddSwaggerGen();

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
// app.UseAuthorization();

// Mapeia controladores e endpoints
app.MapControllers();

app.Run();



