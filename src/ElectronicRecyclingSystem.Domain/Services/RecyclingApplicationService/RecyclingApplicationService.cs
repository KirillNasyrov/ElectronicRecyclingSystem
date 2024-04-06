using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Domain.Features.CreateRecyclingApplication;
using ElectronicRecyclingSystem.Domain.Features.GetRecyclingApplications;
using ElectronicRecyclingSystem.Domain.Models;
using ElectronicRecyclingSystem.Domain.Repositories;

namespace ElectronicRecyclingSystem.Domain.Services.RecyclingApplicationService;

public class RecyclingApplicationService : IRecyclingApplicationService
{
    private readonly IRecyclingApplicationRepository _recyclingApplicationRepository;

    public RecyclingApplicationService(IRecyclingApplicationRepository recyclingApplicationRepository)
    {
        _recyclingApplicationRepository = recyclingApplicationRepository;
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
    
    public async Task<CreateRecyclingApplicationResult> CreateRecyclingApplicationAsync(
        RecyclingApplication recyclingApplication,
        CancellationToken cancellationToken)
    {
        var result = await _recyclingApplicationRepository.Add(recyclingApplication, cancellationToken);
        return new CreateRecyclingApplicationResult(result);
    }
}