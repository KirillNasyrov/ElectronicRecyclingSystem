namespace ElectronicRecyclingSystem.Domain.Features.CreateRecyclingApplication;

public record CreateRecyclingApplicationResult(
    bool IsSuccess,
    long RecyclingApplicationId)
{
    public CreateRecyclingApplicationResult(long RecyclingApplicationId) : this(true, RecyclingApplicationId)
    {
    }
}