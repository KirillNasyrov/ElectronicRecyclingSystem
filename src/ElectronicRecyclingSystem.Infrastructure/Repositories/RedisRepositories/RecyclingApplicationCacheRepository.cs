using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Database.Settings;
using ElectronicRecyclingSystem.Domain.Models;
using ElectronicRecyclingSystem.Domain.Repositories.RedisRepositories;
using StackExchange.Redis;

namespace ElectronicRecyclingSystem.Infrastructure.Repositories.RedisRepositories;

public class RecyclingApplicationCacheRepository
    : RedisRepository, IRecyclingApplicationCacheRepository
{
    protected override TimeSpan KeyTtl => TimeSpan.FromMinutes(5);
    protected override string KeyPrefix => "recycling_applications";
    
    public RecyclingApplicationCacheRepository(
        ConnectionStringsOptions connectionStringsSettings) : base(connectionStringsSettings)
    {
    }
    
    public async Task Add(RecyclingApplication model, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        var connection = await GetConnection();

        var key = GetKey(model.Id!);
        await connection.HashSetAsync(key, new HashEntry[]
        {
            new ("id", model.Id),
            new ("user_id", model.UserId),
            new ("recycling_application_status", JsonSerializer.Serialize(model.Status)),
            new ("created_at_utc", JsonSerializer.Serialize(model.CreatedAtUtc)),
            new ("closed_at_utc", JsonSerializer.Serialize(model.ClosedAtUtc)),
            new ("price", JsonSerializer.Serialize(model.Price))
        });

        await connection.KeyExpireAsync(key, KeyTtl);
    }

    public async Task<RecyclingApplication?> Get(long recyclingApplicationId, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        var connection = await GetConnection();

        var key = GetKey(recyclingApplicationId);
        var fields = await connection.HashGetAllAsync(key);

        if (!fields.Any())
        {
            return null;
        }

        var result = new RecyclingApplication(); 
        foreach (var field in fields)
        {
            if (!field.Value.HasValue)
            {
                continue;
            }

            field.Value.TryParse(out long longValue);
            var strValue = field.Value.ToString();
            
            result = field.Name.ToString() switch
            {
                "id" => result with { Id = longValue },
                "user_id" => result with { UserId = longValue },
                "recycling_application_status" => result with
                {
                    Status = JsonSerializer
                        .Deserialize<RecyclingApplicationStatus>(strValue)
                },
                "created_at_utc" => result with
                {
                    CreatedAtUtc = JsonSerializer
                        .Deserialize<DateTime>(strValue)
                },
                "closed_at_utc" => result with
                {
                    ClosedAtUtc = JsonSerializer
                        .Deserialize<DateTime>(strValue)
                },
                "price" => result with
                {
                    Price = JsonSerializer
                        .Deserialize<decimal>(strValue)
                },
                _ => result
            };
        }

        return result;
    }

    public async Task Delete(long taskId, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        var connection = await GetConnection();

        var key = GetKey(taskId);
        await connection.KeyDeleteAsync(key);
    }
}