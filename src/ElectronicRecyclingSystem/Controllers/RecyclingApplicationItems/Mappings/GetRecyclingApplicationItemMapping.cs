using ElectronicRecyclingSystem.Controllers.RecyclingApplicationItems.Models;
using ElectronicRecyclingSystem.Domain.Features.GetRecyclingApplicationItem;

namespace ElectronicRecyclingSystem.Controllers.RecyclingApplicationItems.Mappings;

public static class GetRecyclingApplicationItemMapping
{
    public static RecyclingApplicationItemResponse MapToResponse(
        this GetRecyclingApplicationItemResult result)
    {
        return new RecyclingApplicationItemResponse(
            result.RecyclingApplicationItem.Id ?? 0,
            result.RecyclingApplicationItem.RecyclingApplicationId,
            result.ElectronicDevice.Id ?? 0,
            result.RecyclingApplicationItem.Quantity,
            result.ElectronicDevice.ImageUrl);
    }
}