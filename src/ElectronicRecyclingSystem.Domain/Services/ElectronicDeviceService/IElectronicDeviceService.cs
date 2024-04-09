using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Domain.Features.GetElectronicDevice;

namespace ElectronicRecyclingSystem.Domain.Services.ElectronicDeviceService;

public interface IElectronicDeviceService
{
    Task<GetElectronicDeviceResult> GetElectronicDevice(
        long electronicDeviceId,
        CancellationToken cancellationToken);

    Task<GetElectronicDeviceResult> GetElectronicDevice(
        string electronicDeviceName,
        CancellationToken cancellationToken);
}