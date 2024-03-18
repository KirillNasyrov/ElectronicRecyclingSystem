namespace ElectronicRecyclingSystem.Controllers.DeliveryApplications.Models.GetDeliveryApplications;

public record GetDeliveryApplicationsRequest(
    int PageNumber = 1,
    int PageSize = 10);