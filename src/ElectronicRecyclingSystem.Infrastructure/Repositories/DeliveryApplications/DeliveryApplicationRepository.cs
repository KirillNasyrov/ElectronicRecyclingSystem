using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Database;
using ElectronicRecyclingSystem.Domain.Models;
using ElectronicRecyclingSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ElectronicRecyclingSystem.Infrastructure.Repositories.DeliveryApplications;

public class DeliveryApplicationRepository : IDeliveryApplicationRepository
{
    private readonly ApplicationContext _applicationContext;

    public DeliveryApplicationRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<ImmutableHashSet<DeliveryApplication>> Get(
        int skip,
        int take,
        CancellationToken cancellationToken)
    {
        var dtos = await _applicationContext.DeliveryApplicationDtos
            .OrderByDescending(dto => dto.Id)
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

        var result = dtos.Select(dto => dto.MapToModel()).ToImmutableHashSet();
        return result;
    }

    public async Task<long> Add(
        DeliveryApplication deliveryApplication,
        CancellationToken cancellationToken)
    {
        var dto = deliveryApplication.MapToDto();
        var result = await _applicationContext.DeliveryApplicationDtos
            .AddAsync(dto, cancellationToken);
        await _applicationContext.SaveChangesAsync(cancellationToken);

        return result.Entity.Id;
    }
}