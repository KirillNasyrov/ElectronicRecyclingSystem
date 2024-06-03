using System;
using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Domain.Repositories.RedisRepositories;

public interface IRecyclingApplicationCacheRepository : IRedisRepository
{
    Task Add(RecyclingApplication model, CancellationToken token);

    Task<RecyclingApplication?> Get(long recyclingApplicationId, CancellationToken token);

    Task Delete(long taskId, CancellationToken token);
}