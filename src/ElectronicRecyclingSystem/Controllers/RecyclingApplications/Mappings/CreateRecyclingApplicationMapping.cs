using System;
using ElectronicRecyclingSystem.Controllers.RecyclingApplications.Models.CreateRecyclingApplication;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Controllers.RecyclingApplications.Mappings;

public static class CreateRecyclingApplicationMapping
{
    public static RecyclingApplication MapToModel(
        this CreateRecyclingApplicationRequest request)
    {
        return new RecyclingApplication(
            null,
            UserId: request.UserId,
            Status: RecyclingApplicationStatus.Created,
            CreatedAtUtc: DateTime.Now.ToUniversalTime(), 
            null);
    }
}