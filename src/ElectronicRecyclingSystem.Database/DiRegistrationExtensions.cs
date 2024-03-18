using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ElectronicRecyclingSystem.Database;

public static class DiRegistrationExtensions
{
    public static IServiceCollection AddPostgres(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql(connectionString));

        return services;
    }
}