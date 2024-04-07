using System.Collections.Immutable;
using System.Linq;
using ElectronicRecyclingSystem.Controllers.RecyclingApplications.Models.GetRecyclingApplications;
using ElectronicRecyclingSystem.Domain.Features.GetRecyclingApplications;

namespace ElectronicRecyclingSystem.Controllers.RecyclingApplications.Mappings;

public static class GetRecyclingApplicationsMapping
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
}