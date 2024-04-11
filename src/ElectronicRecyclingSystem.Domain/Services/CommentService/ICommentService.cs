using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Domain.Features.GetComment;
using ElectronicRecyclingSystem.Domain.Features.GetCommentsByRecyclingApplicationItem;

namespace ElectronicRecyclingSystem.Domain.Services.CommentService;

public interface ICommentService
{
    Task<GetCommentResult> GetComment(
        long electronicDeviceId,
        CancellationToken cancellationToken);
    
    Task<GetCommentsByRecyclingApplicationItemResult> GetCommentsByRecyclingApplicationItem(
        long recyclingApplicationItemId,
        CancellationToken cancellationToken);
}