namespace ElectronicRecyclingSystem.Controllers.DeliveryApplications.Models.CreateDeliveryApplication;

public record CreateDeliveryApplicationRequest(
    string? Name,
    string? Description,
    int CategoryId,
    double Price,
    int Quantity,
    string? Image);