using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Domain.Features.AddRecyclingApplicationItemToApplication;
using ElectronicRecyclingSystem.Domain.Features.GetRecyclingApplicationItem;
using ElectronicRecyclingSystem.Domain.Features.GetRecyclingApplicationItems;
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

    public async Task<AddRecyclingApplicationItemToApplicationResult> AddRecyclingApplicationItemToApplication(
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
                command.Quantity,
                null
            );

            result = await _recyclingApplicationItemRepository
                .Add(recyclingApplicationItemModel, cancellationToken);
            
            return new AddRecyclingApplicationItemToApplicationResult(result);
        }

        recyclingApplicationItemModel = new RecyclingApplicationItem(
            null,
            command.RecyclingApplicationId,
            existingElectronicDevice.Id ?? 0,
            command.Quantity,
            null
        );
        
        result = await _recyclingApplicationItemRepository
            .Add(recyclingApplicationItemModel, cancellationToken);
        
        return new AddRecyclingApplicationItemToApplicationResult(result);
    }

    public async Task<GetRecyclingApplicationItemResult> GetRecyclingApplicationItem(
        long recyclingApplicationItemId,
        CancellationToken cancellationToken)
    {
        var applicationItemModel = await _recyclingApplicationItemRepository
            .Get(recyclingApplicationItemId, cancellationToken);
        
        var electronicDeviceModel = await _electronicDeviceRepository
            .Get(applicationItemModel.ElectronicDeviceId, cancellationToken);

        return new GetRecyclingApplicationItemResult(applicationItemModel, electronicDeviceModel);
    }

    public async Task<GetRecyclingApplicationItemsResult> GetRecyclingApplicationItems(
        long recyclingApplicationId,
        CancellationToken cancellationToken)
    {
        var applicationItemModels = _recyclingApplicationItemRepository
            .GetAllByApplicationId(recyclingApplicationId, cancellationToken);

        var electronicDeviceModels = new List<ElectronicDevice>();
        
        foreach (var itemModel in applicationItemModels)
        {
            electronicDeviceModels.Add(await _electronicDeviceRepository
                .Get(itemModel.ElectronicDeviceId, cancellationToken));
        }

        return new GetRecyclingApplicationItemsResult(
            applicationItemModels,
            electronicDeviceModels.ToImmutableArray());
    }
}