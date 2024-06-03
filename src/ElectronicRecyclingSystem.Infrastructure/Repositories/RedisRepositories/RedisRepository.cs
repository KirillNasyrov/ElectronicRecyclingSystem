using System;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Database.Settings;
using ElectronicRecyclingSystem.Domain.Repositories.RedisRepositories;
using StackExchange.Redis;

namespace ElectronicRecyclingSystem.Infrastructure.Repositories.RedisRepositories;

public abstract class RedisRepository : IRedisRepository
{
    // we must reuse it as it possible
    private static ConnectionMultiplexer? _connection;
    
    private readonly ConnectionStringsOptions _connectionStringsSettings;

    protected RedisRepository(ConnectionStringsOptions connectionStringsSettings)
    {
        _connectionStringsSettings = connectionStringsSettings;
    }

    protected abstract string KeyPrefix { get; }
    
    protected virtual TimeSpan KeyTtl => TimeSpan.MaxValue;
    
    protected async Task<IDatabase> GetConnection()
    {
        _connection ??= await ConnectionMultiplexer.ConnectAsync(_connectionStringsSettings.RedisConnectionString);
        
        return _connection.GetDatabase();
    }
    
    protected RedisKey GetKey(params object[] identifiers)
        => new ($"{KeyPrefix}:{string.Join(':', identifiers)}");
}