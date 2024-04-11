using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Domain.Features.GetComment;
using ElectronicRecyclingSystem.Domain.Features.GetCommentsByRecyclingApplicationItem;
using ElectronicRecyclingSystem.Domain.Models;
using ElectronicRecyclingSystem.Domain.Repositories;

namespace ElectronicRecyclingSystem.Domain.Services.CommentService;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IUserRepository _userRepository;

    public CommentService(
        ICommentRepository commentRepository,
        IUserRepository userRepository)
    {
        _commentRepository = commentRepository;
        _userRepository = userRepository;
    }

    public Task<GetCommentResult> GetComment(
        long electronicDeviceId,
        CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }

    public async Task<GetCommentsByRecyclingApplicationItemResult> GetCommentsByRecyclingApplicationItem(
        long recyclingApplicationItemId,
        CancellationToken cancellationToken)
    {
        var comments = _commentRepository
            .GetCommentsByRecyclingApplicationItem(recyclingApplicationItemId);

        List<User> users = [];

        foreach (var comment in comments)
        {
            users.Add(await _userRepository
                .Get(comment.SenderId, cancellationToken));
        }

        return new GetCommentsByRecyclingApplicationItemResult(
            comments, [..users]);
    }
}