using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Database;
using ElectronicRecyclingSystem.Domain.Models;
using ElectronicRecyclingSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ElectronicRecyclingSystem.Infrastructure.Repositories.RecyclingApplications;

public class RecyclingApplicationRepository : IRecyclingApplicationRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public RecyclingApplicationRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<ImmutableHashSet<RecyclingApplication>> Get(
        int skip,
        int take,
        CancellationToken cancellationToken)
    {
        var dtos = await _applicationDbContext.RecyclingApplicationDtos
            .OrderByDescending(dto => dto.Id)
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

        var result = dtos.Select(dto => dto.MapToModel()).ToImmutableHashSet();
        return result;
    }

    public async Task<RecyclingApplication> Get(
        long id,
        CancellationToken cancellationToken)
    {
        var dto = await _applicationDbContext.RecyclingApplicationDtos.FindAsync(
            [id],
            cancellationToken: cancellationToken);
        return dto!.MapToModel();
    }

    public async Task<long> Add(
        RecyclingApplication recyclingApplication,
        CancellationToken cancellationToken)
    {
        var dto = recyclingApplication.MapToDto();
        var result = await _applicationDbContext.RecyclingApplicationDtos
            .AddAsync(dto, cancellationToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return result.Entity.Id;
    }
}