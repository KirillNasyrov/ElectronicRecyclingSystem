using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Controllers.ElectronicDevices.Mappings;
using ElectronicRecyclingSystem.Controllers.ElectronicDevices.Models;
using ElectronicRecyclingSystem.Domain.Services.ElectronicDeviceService;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicRecyclingSystem.Controllers.ElectronicDevices;

[Route("devices")]
[ApiController]
public class ElectronicDeviceController : ControllerBase
{
    private readonly IElectronicDeviceService _electronicDeviceService;

    public ElectronicDeviceController(IElectronicDeviceService electronicDeviceService)
    {
        _electronicDeviceService = electronicDeviceService;
    }

    [HttpGet("{id:long}")]
    public async Task<ElectronicDeviceResponse> GetElectronicDevice(
        long id,
        CancellationToken cancellationToken)
    {
        var result = await _electronicDeviceService.GetElectronicDevice(id, cancellationToken);
        return result.MapToResponse();
    }
    
    [HttpGet("model")]
    public async Task<ElectronicDeviceResponse> GetElectronicDevice(
        [FromQuery] string model,
        CancellationToken cancellationToken)
    {
        var result = await _electronicDeviceService.GetElectronicDevice(model, cancellationToken);
        return result.MapToResponse();
    }
    
    [HttpPost]
    public async Task<ElectronicDeviceResponse> AddElectronicDevice(
        long id,
        CancellationToken cancellationToken)
    {
        var result = await _electronicDeviceService.GetElectronicDevice(id, cancellationToken);
        return result.MapToResponse();
    }
}