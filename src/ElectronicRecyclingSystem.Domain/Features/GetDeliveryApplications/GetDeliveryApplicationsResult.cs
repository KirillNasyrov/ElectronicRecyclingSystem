using System.Collections.Immutable;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Domain.Features.GetDeliveryApplications;

public record GetDeliveryApplicationsResult(
    ImmutableHashSet<DeliveryApplication> DeliveryApplications);