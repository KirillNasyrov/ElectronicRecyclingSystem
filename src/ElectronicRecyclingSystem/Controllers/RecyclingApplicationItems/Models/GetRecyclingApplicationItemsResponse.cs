using System.Collections.Immutable;

namespace ElectronicRecyclingSystem.Controllers.RecyclingApplicationItems.Models;

public record GetRecyclingApplicationItemsResponse(
    ImmutableArray<RecyclingApplicationItemResponse> RecyclingApplicationItems);