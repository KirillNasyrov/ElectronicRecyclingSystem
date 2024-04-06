using System;
using ElectronicRecyclingSystem.Controllers.Common.RecyclingApplications;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Controllers.RecyclingApplications.Models.CreateRecyclingApplication;

public record CreateRecyclingApplicationRequest(
    long Id,
    long UserId,
    RecyclingApplicationStatusViewModel Status,
    DateTime CreatedAtUtc,
    DateTime ClosedAtUtc);