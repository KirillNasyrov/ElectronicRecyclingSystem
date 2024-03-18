using ElectronicRecyclingSystem.Database.Models;
using ElectronicRecyclingSystem.Domain.Models.CreateDeliveryApplication;
using ElectronicRecyclingSystem.Domain.Models.GetDeliveryApplications;

namespace ElectronicRecyclingSystem.Domain.DeliveryApplication;

public static class DeliveryApplicationMapping
{
    public static DeliveryApplicationInfo MapToDeliveryApplicationInfo(
        this DeliveryApplicationDto deliveryApplication)
    {
        return new DeliveryApplicationInfo(
            Id: deliveryApplication.Id,
            Name: deliveryApplication.Name,
            Description: deliveryApplication.Description,
            CategoryId: deliveryApplication.CategoryId,
            Price: deliveryApplication.Price,
            Quantity: deliveryApplication.Quantity,
            Image: deliveryApplication.Image);
    }

    public static DeliveryApplicationDto MapToDto(
        this CreateDeliveryApplicationCommand command)
    {
        return new DeliveryApplicationDto
        {
            Name = command.Name,
            Description = command.Description,
            CategoryId = command.CategoryId,
            Price = command.Price,
            Quantity = command.Quantity,
            Image = command.Image
        };
    }
}