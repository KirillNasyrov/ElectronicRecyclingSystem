using ElectronicRecyclingSystem.Database.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElectronicRecyclingSystem.Database;

public static class DiRegistrationExtensions
{
    public static void AddDatabaseConnectionStrings(
        this IServiceCollection services, 
        IConfigurationRoot config)
    {
        services.Configure<ConnectionStringsOptions>(
            config.GetSection(nameof(ConnectionStringsOptions)));
    }
    public static void AddPostgres(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));
    }
    
    public static void AddRedis(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = connectionString;
        });
    }
}