using ElectronicRecyclingSystem.Controllers.Common.Mappings;
using ElectronicRecyclingSystem.Controllers.ElectronicDevices.Models;
using ElectronicRecyclingSystem.Domain.Features.GetElectronicDevice;

namespace ElectronicRecyclingSystem.Controllers.ElectronicDevices.Mappings;

public static class GetElectronicDeviceMapping
{
    public static ElectronicDeviceResponse MapToResponse(
        this GetElectronicDeviceResult result)
    {
        return new ElectronicDeviceResponse(
            result.ElectronicDevice!.Id ?? 0,
            result.ElectronicDevice.Name,
            result.ElectronicDevice.Category.MapToResponse(),
            result.ElectronicDevice.ImageUrl);
    }
}