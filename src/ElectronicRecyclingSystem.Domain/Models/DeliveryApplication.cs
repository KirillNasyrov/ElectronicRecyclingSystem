namespace ElectronicRecyclingSystem.Domain.Models;

public record DeliveryApplication(
    string? Name,
    string? Description,
    int CategoryId,
    double Price,
    int Quantity,
    string? Image);