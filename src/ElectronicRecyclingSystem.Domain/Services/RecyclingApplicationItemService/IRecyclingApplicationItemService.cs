using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Domain.Features.AddRecyclingApplicationItemToApplication;

namespace ElectronicRecyclingSystem.Domain.Services.RecyclingApplicationItemService;

public interface IRecyclingApplicationItemService
{
    public Task<AddRecyclingApplicationItemToApplicationResult> AddRecyclingApplicationToApplication(
        AddRecyclingApplicationItemToApplicationCommand command,
        CancellationToken cancellationToken);
}