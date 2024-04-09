using System.Collections.Immutable;
using System.Linq;
using ElectronicRecyclingSystem.Controllers.RecyclingApplicationItems.Models;
using ElectronicRecyclingSystem.Domain.Features.GetRecyclingApplicationItem;
using ElectronicRecyclingSystem.Domain.Features.GetRecyclingApplicationItems;

namespace ElectronicRecyclingSystem.Controllers.RecyclingApplicationItems.Mappings;

public static class GetRecyclingApplicationItemsMapping
{
    public static GetRecyclingApplicationItemsResponse MapToResponse(
        this GetRecyclingApplicationItemsResult result)
    {
        var responses = result.RecyclingApplicationItems
            .Select((t, i) => new GetRecyclingApplicationItemResult(t, result.ElectronicDevices[i]))
            .Select(miniResult => miniResult.MapToResponse())
            .ToImmutableArray();

        return new GetRecyclingApplicationItemsResponse(
            responses);
    }
}