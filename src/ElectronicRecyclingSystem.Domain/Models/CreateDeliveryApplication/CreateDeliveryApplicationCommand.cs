namespace ElectronicRecyclingSystem.Domain.Models.CreateDeliveryApplication;

public record CreateDeliveryApplicationCommand(
    string? Name,
    string? Description,
    int CategoryId,
    double Price,
    int Quantity,
    string? Image);