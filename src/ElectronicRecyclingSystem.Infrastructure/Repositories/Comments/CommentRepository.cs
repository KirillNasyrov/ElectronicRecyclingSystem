using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Database;
using ElectronicRecyclingSystem.Domain.Models;
using ElectronicRecyclingSystem.Domain.Repositories;

namespace ElectronicRecyclingSystem.Infrastructure.Repositories.Comments;

public class CommentRepository : ICommentRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public CommentRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Comment> GetComment(
        long commentId,
        CancellationToken cancellationToken)
    {
        var dto = await _applicationDbContext.CommentDtos
            .FindAsync([commentId], cancellationToken: cancellationToken);

        return dto!.MapToModel();
    }

    public ImmutableArray<Comment> GetCommentsByRecyclingApplicationItem(
        long recyclingApplicationItemId)
    {
        var models = _applicationDbContext.CommentDtos
            .Where(dto => dto.RecyclingApplicationItemId == recyclingApplicationItemId)
            .Select(dto => dto.MapToModel())
            .ToImmutableArray();

        return models;
    }
}