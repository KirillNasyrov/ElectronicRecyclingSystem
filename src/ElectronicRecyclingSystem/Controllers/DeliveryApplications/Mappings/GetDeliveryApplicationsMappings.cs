using System.Collections.Immutable;
using System.Linq;
using ElectronicRecyclingSystem.Controllers.DeliveryApplications.Models.GetDeliveryApplications;
using ElectronicRecyclingSystem.Domain.Features.GetDeliveryApplications;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Controllers.DeliveryApplications.Mappings;

public static class GetDeliveryApplicationsMappings
{
    public static GetDeliveryApplicationsQuery MapToModel(
        this GetDeliveryApplicationsRequest request)
    {
        return new GetDeliveryApplicationsQuery(
            PageNumber: request.PageNumber,
            PageSize: request.PageSize);
    }

    public static GetDeliveryApplicationsResponse MapToResponse(
        this GetDeliveryApplicationsResult result)
    {
        return new GetDeliveryApplicationsResponse(
            result.DeliveryApplications
                .Select(item => item.MapToResponse())
                .ToImmutableArray());
    }

    private static DeliveryApplicationResponse MapToResponse(
        this DeliveryApplication deliveryApplicationInfo)
    {
        return new DeliveryApplicationResponse(
            Name: deliveryApplicationInfo.Name,
            Description: deliveryApplicationInfo.Description,
            CategoryId: deliveryApplicationInfo.CategoryId,
            Price: deliveryApplicationInfo.Price,
            Quantity: deliveryApplicationInfo.Quantity,
            Image: deliveryApplicationInfo.Image);
    }
}