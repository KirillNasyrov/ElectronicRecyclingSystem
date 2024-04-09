using ElectronicRecyclingSystem.Database.Models;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Infrastructure.Repositories.RecyclingApplicationItems;

public static class RecyclingApplicationItemMapping
{
    public static RecyclingApplicationItem MapToModel(
        this RecyclingApplicationItemDto dto)
    {
        return new RecyclingApplicationItem
        (
            dto.Id,
            dto.RecyclingApplicationId,
            dto.ElectronicDeviceId,
            dto.Quantity
        );
    }
    
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