namespace ElectronicRecyclingSystem.Client.Contracts.RecyclingApplicationItems.Models;

public record RecyclingApplicationItemResponse(
    long Id,
    long RecyclingApplicationId,
    long ElectronicDeviceId,
    int Quantity,
    string DeviceName,
    string? ImageUrl,
    decimal? Price);