using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Database;
using ElectronicRecyclingSystem.Domain.Models;
using ElectronicRecyclingSystem.Domain.Repositories;

namespace ElectronicRecyclingSystem.Infrastructure.Repositories.RecyclingApplicationItems;

public class RecyclingApplicationItemRepository : IRecyclingApplicationItemRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public RecyclingApplicationItemRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<long> Add(
        RecyclingApplicationItem recyclingApplicationItem,
        CancellationToken cancellationToken)
    {
        var dto = recyclingApplicationItem.MapToDto();
        var result = await _applicationDbContext.RecyclingApplicationItemsDtos
            .AddAsync(dto, cancellationToken);
        
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        
        return result.Entity.Id;
    }

    public async Task<RecyclingApplicationItem> Get(
        long recyclingApplicationItemId,
        CancellationToken cancellationToken)
    {
        var dto = await _applicationDbContext.RecyclingApplicationItemsDtos
            .FindAsync([recyclingApplicationItemId], cancellationToken: cancellationToken);

        return dto!.MapToModel();
    }

    public ImmutableArray<RecyclingApplicationItem> GetAllByApplicationId(
        long recyclingApplicationId,
        CancellationToken cancellationToken)
    {
        var models = _applicationDbContext.RecyclingApplicationItemsDtos
            .Where(dto => dto.RecyclingApplicationId == recyclingApplicationId)
            .Select(dto => dto.MapToModel())
            .ToImmutableArray();

        return models;
    }
}