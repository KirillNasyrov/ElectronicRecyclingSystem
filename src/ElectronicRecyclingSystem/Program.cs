using System;
using ElectronicRecyclingSystem.Database;
using ElectronicRecyclingSystem.Domain.Repositories;
using ElectronicRecyclingSystem.Domain.Services.RecyclingApplicationItemService;
using ElectronicRecyclingSystem.Domain.Services.RecyclingApplicationService;
using ElectronicRecyclingSystem.Infrastructure.Repositories.ElectronicDevices;
using ElectronicRecyclingSystem.Infrastructure.Repositories.RecyclingApplicationItems;
using ElectronicRecyclingSystem.Infrastructure.Repositories.RecyclingApplications;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("PostgresConnectionString") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddPostgres(connectionString);

builder.Services.AddScoped<IRecyclingApplicationService, RecyclingApplicationService>();
builder.Services.AddScoped<IRecyclingApplicationRepository, RecyclingApplicationRepository>();

builder.Services.AddScoped<IRecyclingApplicationItemRepository, RecyclingApplicationItemRepository>();
builder.Services.AddScoped<IRecyclingApplicationItemService, RecyclingApplicationItemService>();

builder.Services.AddScoped<IElectronicDeviceRepository, ElectronicDeviceRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy => policy.WithOrigins(
    "http://localhost:7156",
    "https://localhost:7156")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType));

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();