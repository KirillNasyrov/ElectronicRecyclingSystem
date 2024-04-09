using ElectronicRecyclingSystem.Client.Contracts.Common.ElectronicDevices;

namespace ElectronicRecyclingSystem.Client.Contracts.ElectronicDevices;

public record ElectronicDeviceResponse(
    long Id,
    string Name,
    ElectronicDeviceCategoryViewModel Category,
    string? ImageUrl);