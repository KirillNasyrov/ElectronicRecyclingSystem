using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Domain.Features.AddRecyclingApplicationItemToApplication;

public record AddRecyclingApplicationItemToApplicationCommand(
    long RecyclingApplicationId,
    string Name,
    ElectronicDeviceCategory Category,
    string? ImageUrl,
    int Quantity);