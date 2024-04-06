using System;
using System.Collections.Immutable;
using ElectronicRecyclingSystem.Client.Contracts.Common.RecyclingApplications;

namespace ElectronicRecyclingSystem.Client.Contracts.RecyclingApplications.Models.GetRecyclingApplications;

public record GetRecyclingApplicationsResponse(
    ImmutableArray<RecyclingApplicationResponse> RecyclingApplications);
    
public record RecyclingApplicationResponse(
    long Id,
    RecyclingApplicationStatusViewModel Status,
    DateTime CreatedAtUtc,
    DateTime ClosedAtUtc
);