namespace ElectronicRecyclingSystem.Controllers.RecyclingApplications.Models.GetRecyclingApplications;

public record GetRecyclingApplicationsRequest(
    int PageNumber = 1,
    int PageSize = 10);