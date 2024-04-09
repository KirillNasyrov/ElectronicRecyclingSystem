using ElectronicRecyclingSystem.Controllers.Common.ElectronicDevices;

namespace ElectronicRecyclingSystem.Controllers.ElectronicDevices.Models;

public record ElectronicDeviceResponse(
    long Id,
    string Name,
    ElectronicDeviceCategoryViewModel Category,
    string? ImageUrl);