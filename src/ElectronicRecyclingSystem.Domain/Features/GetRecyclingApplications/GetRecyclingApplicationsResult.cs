using System.Collections.Immutable;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Domain.Features.GetRecyclingApplications;

public record GetRecyclingApplicationsResult(
    ImmutableHashSet<RecyclingApplication> RecyclingApplications);