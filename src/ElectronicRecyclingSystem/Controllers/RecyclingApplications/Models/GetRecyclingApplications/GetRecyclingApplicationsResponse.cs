using System;
using System.Collections.Immutable;
using ElectronicRecyclingSystem.Controllers.Common.RecyclingApplications;

namespace ElectronicRecyclingSystem.Controllers.RecyclingApplications.Models.GetRecyclingApplications;

public record GetRecyclingApplicationsResponse(
    ImmutableArray<RecyclingApplicationResponse> RecyclingApplications);
    
public record RecyclingApplicationResponse(
    long Id,
    RecyclingApplicationStatusViewModel Status,
    DateTime CreatedAtUtc,
    DateTime? ClosedAtUtc
);