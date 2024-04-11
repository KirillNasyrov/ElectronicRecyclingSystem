using ElectronicRecyclingSystem.Controllers.Common.Mappings;
using ElectronicRecyclingSystem.Controllers.RecyclingApplications.Models.GetRecyclingApplications;
using ElectronicRecyclingSystem.Domain.Features.GetRecyclingApplication;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Controllers.RecyclingApplications.Mappings;

public static class GetRecyclingApplicationMapping
{
    public static RecyclingApplicationResponse MapToResponse (
        this GetRecyclingApplicationResult result)
    {
        return result.RecyclingApplication.MapToResponse();
    }

   public static RecyclingApplicationResponse MapToResponse(
        this RecyclingApplication recyclingApplication)
    {
        return new RecyclingApplicationResponse(
            Id: recyclingApplication.Id ?? 0,
            Status: recyclingApplication.Status.MapToResponse(),
            CreatedAtUtc: recyclingApplication.CreatedAtUtc,
            ClosedAtUtc: recyclingApplication.ClosedAtUtc,
            recyclingApplication.Price);
    }
}