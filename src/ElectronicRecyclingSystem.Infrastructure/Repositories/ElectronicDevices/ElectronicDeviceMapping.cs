using ElectronicRecyclingSystem.Database.Models;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Infrastructure.Repositories.ElectronicDevices;

public static class ElectronicDeviceMapping
{
    public static ElectronicDeviceDto MapToDto(
        this ElectronicDevice model)
    {
        return new ElectronicDeviceDto
        {
            Name = model.Name,
            CategoryId = (short)model.Category,
            ImageUrl = model.ImageUrl
        };
    }
    
    public static ElectronicDevice MapToModel(
        this ElectronicDeviceDto dto)
    {
        return new ElectronicDevice(
            dto.Id,
            dto.Name,
            (ElectronicDeviceCategory)dto.CategoryId,
            dto.ImageUrl);
    }
}