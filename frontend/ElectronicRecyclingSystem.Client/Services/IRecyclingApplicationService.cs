using System.Collections.Immutable;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Client.Contracts.RecyclingApplicationItems.Models;
using ElectronicRecyclingSystem.Client.Contracts.RecyclingApplications.Models.GetRecyclingApplications;

namespace ElectronicRecyclingSystem.Client.Services;

public interface IRecyclingApplicationService
{
    Task<GetRecyclingApplicationsResponse> GetApplications();
    Task<RecyclingApplicationResponse> GetApplication(long id);
    Task<ImmutableArray<RecyclingApplicationItemResponse>> GetRecyclingApplicationItem(long applicationId);
}