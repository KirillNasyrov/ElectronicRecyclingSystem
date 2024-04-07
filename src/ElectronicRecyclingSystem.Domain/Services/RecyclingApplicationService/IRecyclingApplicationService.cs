using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Domain.Features.CreateRecyclingApplication;
using ElectronicRecyclingSystem.Domain.Features.GetRecyclingApplication;
using ElectronicRecyclingSystem.Domain.Features.GetRecyclingApplications;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Domain.Services.RecyclingApplicationService;

public interface IRecyclingApplicationService
{
    public Task<GetRecyclingApplicationsResult> GetRecyclingApplicationsAsync(
        GetRecyclingApplicationsQuery query,
        CancellationToken cancellationToken);

    public Task<GetRecyclingApplicationResult> GetRecyclingApplicationAsync(
        long id,
        CancellationToken cancellationToken);
    public Task<CreateRecyclingApplicationResult> CreateRecyclingApplicationAsync(
        RecyclingApplication command,
        CancellationToken cancellationToken);
}