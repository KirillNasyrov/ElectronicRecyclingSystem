using System;
using ElectronicRecyclingSystem.Database;
using ElectronicRecyclingSystem.Domain.Repositories;
using ElectronicRecyclingSystem.Domain.Repositories.RedisRepositories;
using ElectronicRecyclingSystem.Domain.Services.CommentService;
using ElectronicRecyclingSystem.Domain.Services.ElectronicDeviceService;
using ElectronicRecyclingSystem.Domain.Services.RecyclingApplicationItemService;
using ElectronicRecyclingSystem.Domain.Services.RecyclingApplicationService;
using ElectronicRecyclingSystem.Infrastructure.Repositories.Comments;
using ElectronicRecyclingSystem.Infrastructure.Repositories.ElectronicDevices;
using ElectronicRecyclingSystem.Infrastructure.Repositories.RecyclingApplicationItems;
using ElectronicRecyclingSystem.Infrastructure.Repositories.RecyclingApplications;
using ElectronicRecyclingSystem.Infrastructure.Repositories.RedisRepositories;
using ElectronicRecyclingSystem.Infrastructure.Repositories.Users;
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

var connectionStringPostgres = builder.Configuration.GetConnectionString("PostgresConnectionString") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

var connectionStringRedis = builder.Configuration.GetConnectionString("RedisConnectionString") ??
                               throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services
    .AddDatabaseConnectionStrings(builder.Configuration);

builder.Services.AddPostgres(connectionStringPostgres);
builder.Services.AddRedis(connectionStringRedis);

builder.Services.AddScoped<IRecyclingApplicationService, RecyclingApplicationService>();
builder.Services.AddScoped<IRecyclingApplicationRepository, RecyclingApplicationRepository>();

builder.Services.AddScoped<IRecyclingApplicationItemRepository, RecyclingApplicationItemRepository>();
builder.Services.AddScoped<IRecyclingApplicationItemService, RecyclingApplicationItemService>();

builder.Services.AddScoped<IElectronicDeviceRepository, ElectronicDeviceRepository>();
builder.Services.AddScoped<IElectronicDeviceService, ElectronicDeviceService>();

builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IRecyclingApplicationCacheRepository, RecyclingApplicationCacheRepository>();

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