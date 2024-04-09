using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Domain.Features.GetElectronicDevice;
using ElectronicRecyclingSystem.Domain.Repositories;

namespace ElectronicRecyclingSystem.Domain.Services.ElectronicDeviceService;

public class ElectronicDeviceService : IElectronicDeviceService
{
    private readonly IElectronicDeviceRepository _electronicDeviceRepository;

    public ElectronicDeviceService(IElectronicDeviceRepository electronicDeviceRepository)
    {
        _electronicDeviceRepository = electronicDeviceRepository;
    }

    public async Task<GetElectronicDeviceResult> GetElectronicDevice(
        long electronicDeviceId,
        CancellationToken cancellationToken)
    {
        var electronicDevice = await _electronicDeviceRepository.Get(electronicDeviceId, cancellationToken);
        return new GetElectronicDeviceResult(electronicDevice);
    }

    public async Task<GetElectronicDeviceResult> GetElectronicDevice(
        string electronicDeviceName,
        CancellationToken cancellationToken)
    {
        var electronicDevice = await _electronicDeviceRepository.Get(electronicDeviceName, cancellationToken);
        return new GetElectronicDeviceResult(electronicDevice);
    }
}