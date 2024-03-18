namespace ElectronicRecyclingSystem.Domain.Models.GetDeliveryApplications;

public record GetDeliveryApplicationsQuery(
    int PageNumber = 1,
    int PageSize = 10);