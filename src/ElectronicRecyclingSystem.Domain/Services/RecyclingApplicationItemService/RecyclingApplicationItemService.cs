using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Domain.Features.AddRecyclingApplicationItemToApplication;
using ElectronicRecyclingSystem.Domain.Models;
using ElectronicRecyclingSystem.Domain.Repositories;

namespace ElectronicRecyclingSystem.Domain.Services.RecyclingApplicationItemService;

public class RecyclingApplicationItemService : IRecyclingApplicationItemService
{
    private readonly IRecyclingApplicationItemRepository _recyclingApplicationItemRepository;
    private readonly IElectronicDeviceRepository _electronicDeviceRepository;

    public RecyclingApplicationItemService(
        IRecyclingApplicationItemRepository recyclingApplicationItemRepository,
        IElectronicDeviceRepository electronicDeviceRepository)
    {
        _recyclingApplicationItemRepository = recyclingApplicationItemRepository;
        _electronicDeviceRepository = electronicDeviceRepository;
    }

    public async Task<AddRecyclingApplicationItemToApplicationResult> AddRecyclingApplicationToApplication(
        AddRecyclingApplicationItemToApplicationCommand command,
        CancellationToken cancellationToken)
    {
        RecyclingApplicationItem recyclingApplicationItemModel;
        long result;

        var existingElectronicDevice = await _electronicDeviceRepository
            .Get(command.Name, cancellationToken);

        if (existingElectronicDevice is null)
        {
            var electronicDeviceModel = new ElectronicDevice(
                null,
                command.Name,
                command.Category,
                command.ImageUrl);

            var electronicDeviceId = await _electronicDeviceRepository
                .Add(electronicDeviceModel, cancellationToken);

            recyclingApplicationItemModel = new RecyclingApplicationItem(
                null,
                command.RecyclingApplicationId,
                electronicDeviceId,
                command.Quantity
            );

            result = await _recyclingApplicationItemRepository
                .Add(recyclingApplicationItemModel, cancellationToken);
            
            return new AddRecyclingApplicationItemToApplicationResult(result);
        }

        recyclingApplicationItemModel = new RecyclingApplicationItem(
            null,
            command.RecyclingApplicationId,
            existingElectronicDevice.Id ?? 0,
            command.Quantity
        );
        
        result = await _recyclingApplicationItemRepository
            .Add(recyclingApplicationItemModel, cancellationToken);
        
        return new AddRecyclingApplicationItemToApplicationResult(result);
    }
}