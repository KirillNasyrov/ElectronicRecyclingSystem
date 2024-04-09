using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Domain.Features.AddRecyclingApplicationItemToApplication;
using ElectronicRecyclingSystem.Domain.Features.GetRecyclingApplicationItem;
using ElectronicRecyclingSystem.Domain.Features.GetRecyclingApplicationItems;

namespace ElectronicRecyclingSystem.Domain.Services.RecyclingApplicationItemService;

public interface IRecyclingApplicationItemService
{
    public Task<AddRecyclingApplicationItemToApplicationResult> AddRecyclingApplicationItemToApplication(
        AddRecyclingApplicationItemToApplicationCommand command,
        CancellationToken cancellationToken);
    
    public Task<GetRecyclingApplicationItemResult> GetRecyclingApplicationItem(
        long recyclingApplicationItemId,
        CancellationToken cancellationToken);
    
    public Task<GetRecyclingApplicationItemsResult> GetRecyclingApplicationItems(
        long recyclingApplicationId,
        CancellationToken cancellationToken);
}