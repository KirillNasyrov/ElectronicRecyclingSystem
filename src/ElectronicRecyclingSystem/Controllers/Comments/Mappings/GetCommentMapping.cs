using ElectronicRecyclingSystem.Controllers.Comments.Models;
using ElectronicRecyclingSystem.Domain.Features.GetComment;

namespace ElectronicRecyclingSystem.Controllers.Comments.Mappings;

public static class GetCommentMapping
{
    public static CommentResponse MapToResponse(
        this GetCommentResult result)
    {
        return new CommentResponse(
            result.Comment!.Text,
            result.Comment.SenderId,
            result.Comment.SentAt,
            result.User!.Name,
            result.User.Surname);
    }
}