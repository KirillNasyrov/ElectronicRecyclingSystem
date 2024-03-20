using System.Collections.Immutable;

namespace ElectronicRecyclingSystem.Controllers.DeliveryApplications.Models.GetDeliveryApplications;

public record GetDeliveryApplicationsResponse(
    ImmutableArray<DeliveryApplicationResponse> DeliveryApplications);
    
public record DeliveryApplicationResponse(
    string? Name,
    string? Description,
    int CategoryId,
    double Price,
    int Quantity,
    string? Image
);