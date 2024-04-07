using ElectronicRecyclingSystem.Database.Models;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Infrastructure.Repositories.RecyclingApplicationItems;

public static class RecyclingApplicationItemMapping
{
    public static RecyclingApplicationItemDto MapToDto(
        this RecyclingApplicationItem model)
    {
        return new RecyclingApplicationItemDto
        {
            RecyclingApplicationId = model.RecyclingApplicationId,
            ElectronicDeviceId = model.ElectronicDeviceId,
            Quantity = model.Quantity
        };
    }
    
    public static RecyclingApplicationItemDto MapToDto(
        this RecyclingApplicationItem model,
        long recyclingApplicationItemId)
    {
        return new RecyclingApplicationItemDto
        {
            Id = recyclingApplicationItemId,
            RecyclingApplicationId = model.RecyclingApplicationId,
            ElectronicDeviceId = model.ElectronicDeviceId,
            Quantity = model.Quantity
        };
    }
}