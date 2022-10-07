using Microsoft.EntityFrameworkCore;
using SAIM.Application.Interface;
using SAIM.Application.Main;
using SAIM.Controller.Interface;
using SAIM.Domain.Entities.Models;
using SAIM.Domain.Repository;
using SAIM.Services;
using SAIM.Services.AppStart;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

builder.Services.AddSingleton<IConfiguration>(configuration);

// Add services to the container.
builder.Services.AddDependencies(configuration);

builder.Services.AddControllers().AddJsonOptions(options =>
options.JsonSerializerOptions.WriteIndented = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


builder.Services.AddDbContext<SaimContext>(options =>
{
    options.UseMySQL(configuration.GetConnectionString("SAIMMySql"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});


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
