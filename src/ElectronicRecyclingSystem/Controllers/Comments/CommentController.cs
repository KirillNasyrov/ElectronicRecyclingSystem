using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Controllers.Comments.Mappings;
using ElectronicRecyclingSystem.Controllers.Comments.Models;
using ElectronicRecyclingSystem.Domain.Services.CommentService;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicRecyclingSystem.Controllers.Comments;

[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet("comments/{commendId:long}")]
    public async Task<CommentResponse> GetComment(
        [FromRoute] long commendId,
        CancellationToken cancellationToken)
    {
        var result = await _commentService.GetComment(commendId, cancellationToken);
        return result.MapToResponse();
    }
    
    [HttpGet("application-items/{recyclingApplicationItemId:long}/comments")]
    public async Task<GetCommentsByRecyclingApplicationItemResponse> GetCommentsByRecyclingApplicationItem(
        [FromRoute] long recyclingApplicationItemId,
        CancellationToken cancellationToken)
    {
        var result = await _commentService
            .GetCommentsByRecyclingApplicationItem(recyclingApplicationItemId, cancellationToken);
        return result.MapToResponse();
    }
    
    [HttpPost("application-items/{recyclingApplicationItemId:long}/comments")]
    public async Task<GetCommentsByRecyclingApplicationItemResponse> AddComment(
        [FromRoute] long recyclingApplicationItemId,
        CancellationToken cancellationToken)
    {
        var result = await _commentService
            .GetCommentsByRecyclingApplicationItem(recyclingApplicationItemId, cancellationToken);
        return result.MapToResponse();
    }
}