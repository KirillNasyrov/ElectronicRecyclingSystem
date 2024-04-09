using System.Collections.Immutable;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Domain.Features.GetRecyclingApplicationItems;

public record GetRecyclingApplicationItemsResult(
    ImmutableArray<RecyclingApplicationItem> RecyclingApplicationItems,
    ImmutableArray<ElectronicDevice> ElectronicDevices);