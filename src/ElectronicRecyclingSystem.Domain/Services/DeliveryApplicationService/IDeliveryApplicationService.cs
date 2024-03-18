using ElectronicRecyclingSystem.Domain.Models.CreateDeliveryApplication;
using ElectronicRecyclingSystem.Domain.Models.GetDeliveryApplications;

namespace ElectronicRecyclingSystem.Domain.Services.DeliveryApplicationService;

public interface IDeliveryApplicationService
{
    public Task<GetDeliveryApplicationsResult> GetDeliveryApplicationsAsync(
        GetDeliveryApplicationsQuery query);

    public Task<CreateDeliveryApplicationResult> CreateDeliveryApplicationAsync(
        CreateDeliveryApplicationCommand command);
}