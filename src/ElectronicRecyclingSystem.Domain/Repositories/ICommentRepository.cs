using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Domain.Repositories;

public interface ICommentRepository
{
    public Task<Comment> GetComment(
        long commentId,
        CancellationToken cancellationToken);

    public ImmutableArray<Comment> GetCommentsByRecyclingApplicationItem(
        long recyclingApplicationItemId);
}