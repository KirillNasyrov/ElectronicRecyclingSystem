using System.Collections.Immutable;
using ElectronicRecyclingSystem.Database;
using ElectronicRecyclingSystem.Domain.DeliveryApplication;
using ElectronicRecyclingSystem.Domain.Models.CreateDeliveryApplication;
using ElectronicRecyclingSystem.Domain.Models.GetDeliveryApplications;
using Microsoft.EntityFrameworkCore;

namespace ElectronicRecyclingSystem.Domain.Services.DeliveryApplicationService;

public class DeliveryApplicationService : IDeliveryApplicationService
{
    private readonly ApplicationContext _applicationContext;

    public DeliveryApplicationService(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }
    
    public async Task<GetDeliveryApplicationsResult> GetDeliveryApplicationsAsync(
        GetDeliveryApplicationsQuery query)
    {
        var result = await _applicationContext.DeliveryApplicationDtos.ToListAsync();
        return new GetDeliveryApplicationsResult(
            DeliveryApplications: result.Select(
                dto => dto.MapToDeliveryApplicationInfo()).ToImmutableArray());
    }
    
    public async Task<CreateDeliveryApplicationResult> CreateDeliveryApplicationAsync(
        CreateDeliveryApplicationCommand command)
    {
        var dto = command.MapToDto();
        var result = await _applicationContext.DeliveryApplicationDtos.AddAsync(dto);
        await _applicationContext.SaveChangesAsync();
        return new CreateDeliveryApplicationResult(result.Entity.Id);
    }
}