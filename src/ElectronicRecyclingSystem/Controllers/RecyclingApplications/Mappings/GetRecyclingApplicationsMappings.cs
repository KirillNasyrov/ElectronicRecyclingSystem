using System.Collections.Immutable;
using System.Linq;
using ElectronicRecyclingSystem.Controllers.Common.Mappings;
using ElectronicRecyclingSystem.Controllers.RecyclingApplications.Models.GetRecyclingApplications;
using ElectronicRecyclingSystem.Domain.Features.GetRecyclingApplications;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Controllers.RecyclingApplications.Mappings;

public static class GetRecyclingApplicationsMappings
{
    public static GetRecyclingApplicationsQuery MapToModel(
        this GetRecyclingApplicationsRequest request)
    {
        return new GetRecyclingApplicationsQuery(
            PageNumber: request.PageNumber,
            PageSize: request.PageSize);
    }

    public static GetRecyclingApplicationsResponse MapToResponse(
        this GetRecyclingApplicationsResult result)
    {
        return new GetRecyclingApplicationsResponse(
            result.RecyclingApplications
                .Select(item => item.MapToResponse())
                .ToImmutableArray());
    }

    private static RecyclingApplicationResponse MapToResponse(
        this RecyclingApplication recyclingApplication)
    {
        return new RecyclingApplicationResponse(
            Id: recyclingApplication.Id,
            Status: recyclingApplication.Status.MapToResponse(),
            CreatedAtUtc: recyclingApplication.CreatedAtUtc,
            ClosedAtUtc: recyclingApplication.ClosedAtUtc);
    }
}