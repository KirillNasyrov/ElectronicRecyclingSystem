namespace ElectronicRecyclingSystem.Domain.Features.CreateDeliveryApplication;

public record CreateDeliveryApplicationResult(
    bool IsSuccess,
    long DeliveryApplicationId)
{
    public CreateDeliveryApplicationResult(long DeliveryApplicationId) : this(true, DeliveryApplicationId)
    {
    }
}