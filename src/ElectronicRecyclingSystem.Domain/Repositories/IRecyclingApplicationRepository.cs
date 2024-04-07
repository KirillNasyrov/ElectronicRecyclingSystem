using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Domain.Repositories;

public interface IRecyclingApplicationRepository
{
    Task<ImmutableHashSet<RecyclingApplication>> Get(
        int skip,
        int take,
        CancellationToken cancellationToken);

    Task<RecyclingApplication> Get(
        long id,
        CancellationToken cancellationToken);
    
    public Task<long> Add(
        RecyclingApplication recyclingApplication,
        CancellationToken cancellationToken);
}