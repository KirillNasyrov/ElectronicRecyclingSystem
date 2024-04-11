using System.Collections.Immutable;

namespace ElectronicRecyclingSystem.Controllers.Comments.Models;

public record GetCommentsByRecyclingApplicationItemResponse(
    ImmutableArray<CommentResponse> Comments);
