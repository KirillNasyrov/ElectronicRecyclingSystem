using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Domain.Repositories;

public interface IRecyclingApplicationItemRepository
{
    public Task<long> Add(
        RecyclingApplicationItem recyclingApplicationItem,
        CancellationToken cancellationToken);

    public Task<RecyclingApplicationItem> Get(
        long recyclingApplicationItemId,
        CancellationToken cancellationToken);

    public ImmutableArray<RecyclingApplicationItem> GetAllByApplicationId(
        long recyclingApplicationId,
        CancellationToken cancellationToken);
}