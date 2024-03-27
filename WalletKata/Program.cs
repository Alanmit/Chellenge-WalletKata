using Domain.Models.Entities;
using Infrastructure.Boopstrap;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Wallet Kata", Version = "v1"});
});

//builder.Services.AddControllers();
//builder.Services.AddRouting();
//builder.Services.AddRoutingCore();
builder.Services.AddApiVersioning(c =>
{
    c.DefaultApiVersion = new ApiVersion(1, 0);
    c.AssumeDefaultVersionWhenUnspecified = true;
}); 

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddDbContext<WalletKataDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetSection("DataAccessRegistry:ConnectionStrings").Value));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
