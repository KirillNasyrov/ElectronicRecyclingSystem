using System;
using ElectronicRecyclingSystem.Client.Contracts.Common.RecyclingApplications;

namespace ElectronicRecyclingSystem.Client.Contracts.RecyclingApplications.Models.CreateRecyclingApplication;

public record CreateRecyclingApplicationRequest(
    long Id,
    long UserId,
    RecyclingApplicationStatusViewModel Status,
    DateTime CreatedAtUtc,
    DateTime ClosedAtUtc);