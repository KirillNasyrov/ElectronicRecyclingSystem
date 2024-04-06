using ElectronicRecyclingSystem.Controllers.RecyclingApplications.Models.CreateRecyclingApplication;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Controllers.RecyclingApplications.Mappings;

public static class CreateRecyclingApplicationMappings
{
    public static RecyclingApplication MapToModel(
        this CreateRecyclingApplicationRequest request)
    {
        return new RecyclingApplication(
            Id: request.Id,
            UserId: request.UserId,
            Status: RecyclingApplicationStatus.Created,
            CreatedAtUtc: request.CreatedAtUtc,
            ClosedAtUtc: request.ClosedAtUtc);
    }
}