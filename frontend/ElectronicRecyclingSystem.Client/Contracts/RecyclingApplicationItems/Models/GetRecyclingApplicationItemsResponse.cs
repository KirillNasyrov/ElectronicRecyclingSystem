using System.Collections.Immutable;

namespace ElectronicRecyclingSystem.Client.Contracts.RecyclingApplicationItems.Models;

public record GetRecyclingApplicationItemsResponse(
    ImmutableArray<RecyclingApplicationItemResponse> RecyclingApplicationItems);