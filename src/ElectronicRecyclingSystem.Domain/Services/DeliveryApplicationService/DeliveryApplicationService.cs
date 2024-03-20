using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Domain.Features.CreateDeliveryApplication;
using ElectronicRecyclingSystem.Domain.Features.GetDeliveryApplications;
using ElectronicRecyclingSystem.Domain.Models;
using ElectronicRecyclingSystem.Domain.Repositories;

namespace ElectronicRecyclingSystem.Domain.Services.DeliveryApplicationService;

public class DeliveryApplicationService : IDeliveryApplicationService
{
    private readonly IDeliveryApplicationRepository _deliveryApplicationRepository;

    public DeliveryApplicationService(IDeliveryApplicationRepository deliveryApplicationRepository)
    {
        _deliveryApplicationRepository = deliveryApplicationRepository;
    }

    public async Task<GetDeliveryApplicationsResult> GetDeliveryApplicationsAsync(
        GetDeliveryApplicationsQuery query,
        CancellationToken cancellationToken)
    {
        var skip = (query.PageNumber - 1) * query.PageSize;
        var take = query.PageSize;
        var deliveryApplications = await _deliveryApplicationRepository.Get(skip, take, cancellationToken);
        return new GetDeliveryApplicationsResult(deliveryApplications);
    }
    
    public async Task<CreateDeliveryApplicationResult> CreateDeliveryApplicationAsync(
        DeliveryApplication deliveryApplication,
        CancellationToken cancellationToken)
    {
        var result = await _deliveryApplicationRepository.Add(deliveryApplication, cancellationToken);
        return new CreateDeliveryApplicationResult(result);
    }
}