using ElectronicRecyclingSystem.Database.Models;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Infrastructure.Repositories.DeliveryApplications;

public static class DeliveryApplicationMapping
{
    public static DeliveryApplication MapToModel(
        this DeliveryApplicationDto dto)
    {
        return new DeliveryApplication(
            Name: dto.Name,
            Description: dto.Description,
            CategoryId: dto.CategoryId,
            Price: dto.Price,
            Quantity: dto.Quantity,
            Image: dto.Image);
    }

    public static DeliveryApplicationDto MapToDto(
        this DeliveryApplication model)
    {
        return new DeliveryApplicationDto
        {
            Name = model.Name,
            Description = model.Description,
            CategoryId = model.CategoryId,
            Price = model.Price,
            Quantity = model.Quantity,
            Image = model.Image
        };
    }
}