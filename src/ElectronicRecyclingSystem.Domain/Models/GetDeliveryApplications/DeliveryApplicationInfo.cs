namespace ElectronicRecyclingSystem.Domain.Models.GetDeliveryApplications;

public record DeliveryApplicationInfo(
    long Id,
    string? Name,
    string? Description,
    int CategoryId,
    double Price,
    int Quantity,
    string? Image);