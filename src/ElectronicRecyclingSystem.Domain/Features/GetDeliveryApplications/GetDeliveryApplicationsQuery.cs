namespace ElectronicRecyclingSystem.Domain.Features.GetDeliveryApplications;

public record GetDeliveryApplicationsQuery(
    int PageNumber = 1,
    int PageSize = 10);