using System.Collections;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Client.Contracts.RecyclingApplications.Models.GetRecyclingApplications;

namespace ElectronicRecyclingSystem.Client.Services;

public interface IRecyclingApplicationService
{
    Task<GetRecyclingApplicationsResponse> GetApplications();
}