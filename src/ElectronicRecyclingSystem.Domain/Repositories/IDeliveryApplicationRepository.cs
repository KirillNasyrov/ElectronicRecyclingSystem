using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Domain.Repositories;

public interface IDeliveryApplicationRepository
{
    Task<ImmutableHashSet<DeliveryApplication>> Get(
        int skip,
        int take,
        CancellationToken cancellationToken);
    
    public Task<long> Add(
        DeliveryApplication deliveryApplication,
        CancellationToken cancellationToken);
}