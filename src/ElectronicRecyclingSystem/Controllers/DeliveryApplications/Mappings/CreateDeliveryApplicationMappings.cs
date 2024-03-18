using ElectronicRecyclingSystem.Controllers.DeliveryApplications.Models.CreateDeliveryApplication;
using ElectronicRecyclingSystem.Domain.Models.CreateDeliveryApplication;

namespace ElectronicRecyclingSystem.Controllers.DeliveryApplications.Mappings;

public static class CreateDeliveryApplicationMappings
{
    public static CreateDeliveryApplicationCommand MapToModel(
        this CreateDeliveryApplicationRequest request)
    {
        return new CreateDeliveryApplicationCommand(
            Name: request.Name,
            Description: request.Description,
            CategoryId: request.CategoryId,
            Price: request.Price,
            Quantity: request.Quantity,
            Image: request.Image);
    }
}