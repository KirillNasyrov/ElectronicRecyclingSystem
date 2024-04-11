using System.Collections.Generic;
using System.Linq;
using ElectronicRecyclingSystem.Controllers.Comments.Models;
using ElectronicRecyclingSystem.Domain.Features.GetCommentsByRecyclingApplicationItem;

namespace ElectronicRecyclingSystem.Controllers.Comments.Mappings;

public static class GetCommentsByRecyclingApplicationItemMapping
{
    public static GetCommentsByRecyclingApplicationItemResponse MapToResponse(
        this GetCommentsByRecyclingApplicationItemResult result)
    {
        List<CommentResponse> comments = [];
        comments.AddRange(result.Comments
            .Select((t, i) => 
                new CommentResponse(t.Text, t.SenderId, t.SentAt, result.Users[i].Name, result.Users[i].Surname)));
        return new GetCommentsByRecyclingApplicationItemResponse(
            [..comments]);
    }
}