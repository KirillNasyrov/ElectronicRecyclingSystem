namespace ElectronicRecyclingSystem.Domain.Models;

public record ElectronicDevice(
    long? Id,
    string Name,
    ElectronicDeviceCategory Category,
    string? ImageUrl);