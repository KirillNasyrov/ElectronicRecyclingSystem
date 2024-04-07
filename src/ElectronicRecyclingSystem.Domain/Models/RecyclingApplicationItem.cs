namespace ElectronicRecyclingSystem.Domain.Models;

public record RecyclingApplicationItem(
    long? Id,
    long RecyclingApplicationId,
    long ElectronicDeviceId,
    int Quantity);