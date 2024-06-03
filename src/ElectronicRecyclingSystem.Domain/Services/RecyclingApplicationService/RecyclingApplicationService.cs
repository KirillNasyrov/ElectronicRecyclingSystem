using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Domain.Features.CreateRecyclingApplication;
using ElectronicRecyclingSystem.Domain.Features.GetRecyclingApplication;
using ElectronicRecyclingSystem.Domain.Features.GetRecyclingApplications;
using ElectronicRecyclingSystem.Domain.Models;
using ElectronicRecyclingSystem.Domain.Repositories;
using ElectronicRecyclingSystem.Domain.Repositories.RedisRepositories;

namespace ElectronicRecyclingSystem.Domain.Services.RecyclingApplicationService;

public class RecyclingApplicationService : IRecyclingApplicationService
{
    private readonly IRecyclingApplicationRepository _recyclingApplicationRepository;
    private readonly IRecyclingApplicationCacheRepository _recyclingApplicationCacheRepository;

    public RecyclingApplicationService(
        IRecyclingApplicationRepository recyclingApplicationRepository,
        IRecyclingApplicationCacheRepository recyclingApplicationCacheRepository)
    {
        _recyclingApplicationRepository = recyclingApplicationRepository;
        _recyclingApplicationCacheRepository = recyclingApplicationCacheRepository;
    }

    public async Task<GetRecyclingApplicationsResult> GetRecyclingApplicationsAsync(
        GetRecyclingApplicationsQuery query,
        CancellationToken cancellationToken)
    {
        var skip = (query.PageNumber - 1) * query.PageSize;
        var take = query.PageSize;
        var recyclingApplications = await _recyclingApplicationRepository.Get(skip, take, cancellationToken);
        return new GetRecyclingApplicationsResult(recyclingApplications);
    }
    
    public async Task<GetRecyclingApplicationResult> GetRecyclingApplicationAsync(
        long id,
        CancellationToken cancellationToken)
    {
        var cachedRecyclingApplication = await _recyclingApplicationCacheRepository.Get(id, cancellationToken);
        
        if (cachedRecyclingApplication is not null)
        {
            return new GetRecyclingApplicationResult(cachedRecyclingApplication);
        }
        
        var recyclingApplication = await _recyclingApplicationRepository.Get(id, cancellationToken);
        await _recyclingApplicationCacheRepository.Add(recyclingApplication, cancellationToken);
        
        return new GetRecyclingApplicationResult(recyclingApplication);
    }
    
    public async Task<CreateRecyclingApplicationResult> CreateRecyclingApplicationAsync(
        RecyclingApplication recyclingApplication,
        CancellationToken cancellationToken)
    {
        var result = await _recyclingApplicationRepository.Add(recyclingApplication, cancellationToken);
        await _recyclingApplicationCacheRepository.Add(recyclingApplication, cancellationToken);
        
        return new CreateRecyclingApplicationResult(result);
    }
}