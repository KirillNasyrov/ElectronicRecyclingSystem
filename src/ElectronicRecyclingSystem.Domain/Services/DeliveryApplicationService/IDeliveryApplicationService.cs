using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Domain.Features.CreateDeliveryApplication;
using ElectronicRecyclingSystem.Domain.Features.GetDeliveryApplications;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Domain.Services.DeliveryApplicationService;

public interface IDeliveryApplicationService
{
    public Task<GetDeliveryApplicationsResult> GetDeliveryApplicationsAsync(
        GetDeliveryApplicationsQuery query,
        CancellationToken cancellationToken);

    public Task<CreateDeliveryApplicationResult> CreateDeliveryApplicationAsync(
        DeliveryApplication command,
        CancellationToken cancellationToken);
}