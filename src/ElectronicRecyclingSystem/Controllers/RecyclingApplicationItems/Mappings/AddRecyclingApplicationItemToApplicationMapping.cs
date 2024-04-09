using ElectronicRecyclingSystem.Controllers.Common.Mappings;
using ElectronicRecyclingSystem.Controllers.RecyclingApplicationItems.Models;
using ElectronicRecyclingSystem.Domain.Features.AddRecyclingApplicationItemToApplication;

namespace ElectronicRecyclingSystem.Controllers.RecyclingApplicationItems.Mappings;

public static class AddRecyclingApplicationItemToApplicationMapping
{
    public static AddRecyclingApplicationItemToApplicationCommand MapToModel(
        this AddRecyclingApplicationItemToApplicationRequest request,
        long recyclingApplicationId)
    {
        return new AddRecyclingApplicationItemToApplicationCommand(
            recyclingApplicationId,
            request.Name,
            request.Category.MapToModel(),
            null,
            request.Quantity);
    }
}