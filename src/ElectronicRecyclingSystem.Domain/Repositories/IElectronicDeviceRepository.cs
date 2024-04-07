using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Domain.Repositories;

public interface IElectronicDeviceRepository
{
    public Task<ElectronicDevice> Get(
        long electronicDeviceId,
        CancellationToken cancellationToken);

    public Task<ElectronicDevice?> Get(
        string modelName,
        CancellationToken cancellationToken);
    
    public Task<long> Add(
        ElectronicDevice electronicDevice,
        CancellationToken cancellationToken);
}