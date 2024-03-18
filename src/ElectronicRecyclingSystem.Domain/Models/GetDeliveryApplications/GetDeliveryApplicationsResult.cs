using System.Collections.Immutable;
using ElectronicRecyclingSystem.Database.Models;

namespace ElectronicRecyclingSystem.Domain.Models.GetDeliveryApplications;

public record GetDeliveryApplicationsResult(
    ImmutableArray<DeliveryApplicationInfo> DeliveryApplications);