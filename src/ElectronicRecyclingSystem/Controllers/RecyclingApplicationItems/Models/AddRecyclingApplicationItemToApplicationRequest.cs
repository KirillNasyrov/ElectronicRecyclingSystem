using ElectronicRecyclingSystem.Controllers.Common.ElectronicDevices;

namespace ElectronicRecyclingSystem.Controllers.RecyclingApplicationItems.Models;

public record AddRecyclingApplicationItemToApplicationRequest(
    string Name,
    ElectronicDeviceCategoryViewModel Category,
    string? ImageUrl,
    int Quantity);