using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Database;
using ElectronicRecyclingSystem.Domain.Models;
using ElectronicRecyclingSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ElectronicRecyclingSystem.Infrastructure.Repositories.ElectronicDevices;

public class ElectronicDeviceRepository : IElectronicDeviceRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ElectronicDeviceRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<ElectronicDevice> Get(long electronicDeviceId, CancellationToken cancellationToken)
    {
        var dto = await _applicationDbContext.ElectronicDeviceDtos.FindAsync(
            [electronicDeviceId],
            cancellationToken: cancellationToken);

        return dto!.MapToModel();
    }
    
    public async Task<ElectronicDevice?> Get(string modelName, CancellationToken cancellationToken)
    {
        var inputModelName = modelName.ToLower().Replace(" ", "");

        var dto = await _applicationDbContext.ElectronicDeviceDtos.FirstOrDefaultAsync(
            device => device.Name.ToLower().Replace(" ", "") == inputModelName,
            cancellationToken: cancellationToken);
        return dto?.MapToModel();
    }
    
    public async Task<long> Add(
        ElectronicDevice electronicDevice,
        CancellationToken cancellationToken)
    {
        var dto = electronicDevice.MapToDto();
        var result = await _applicationDbContext.ElectronicDeviceDtos
            .AddAsync(dto, cancellationToken);
        
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        
        return result.Entity.Id;
    }
}