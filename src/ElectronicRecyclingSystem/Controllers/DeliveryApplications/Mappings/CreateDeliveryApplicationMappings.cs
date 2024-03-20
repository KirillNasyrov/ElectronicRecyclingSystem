using ElectronicRecyclingSystem.Controllers.DeliveryApplications.Models.CreateDeliveryApplication;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Controllers.DeliveryApplications.Mappings;

public static class CreateDeliveryApplicationMappings
{
    public static DeliveryApplication MapToModel(
        this CreateDeliveryApplicationRequest request)
    {
        return new DeliveryApplication(
            Name: request.Name,
            Description: request.Description,
            CategoryId: request.CategoryId,
            Price: request.Price,
            Quantity: request.Quantity,
            Image: request.Image);
    }
}