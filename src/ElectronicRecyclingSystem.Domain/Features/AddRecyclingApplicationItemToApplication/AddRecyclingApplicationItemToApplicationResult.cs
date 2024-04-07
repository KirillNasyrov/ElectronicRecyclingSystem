namespace ElectronicRecyclingSystem.Domain.Features.AddRecyclingApplicationItemToApplication;

public record AddRecyclingApplicationItemToApplicationResult(
    bool IsSuccess,
    long RecyclingApplicationItemId)
{
    public AddRecyclingApplicationItemToApplicationResult(long RecyclingApplicationItemId)
        : this(true, RecyclingApplicationItemId) { }
}