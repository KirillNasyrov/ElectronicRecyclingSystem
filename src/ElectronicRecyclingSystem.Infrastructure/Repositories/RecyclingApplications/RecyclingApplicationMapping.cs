using ElectronicRecyclingSystem.Database.Models;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Infrastructure.Repositories.RecyclingApplications;

public static class RecyclingApplicationMapping
{
    public static RecyclingApplication MapToModel(
        this RecyclingApplicationDto dto)
    {
        return new RecyclingApplication
        (
            Id: dto.Id,
            UserId: dto.UserId,
            Status: (RecyclingApplicationStatus)dto.StatusId,
            CreatedAtUtc: dto.CreatedAtUtc,
            ClosedAtUtc: dto.ClosedAtUtc
        );
    }

    public static RecyclingApplicationDto MapToDto(
        this RecyclingApplication model)
    {
        return new RecyclingApplicationDto
        {
            UserId = model.UserId,
            StatusId = (short)model.Status,
            CreatedAtUtc = model.CreatedAtUtc,
            ClosedAtUtc = model.ClosedAtUtc
        };
    }
}