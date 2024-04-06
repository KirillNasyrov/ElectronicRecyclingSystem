namespace ElectronicRecyclingSystem.Domain.Features.GetRecyclingApplications;

public record GetRecyclingApplicationsQuery(
    int PageNumber = 1,
    int PageSize = 10);