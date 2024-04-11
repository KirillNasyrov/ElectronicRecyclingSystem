using System.Collections.Immutable;

namespace ElectronicRecyclingSystem.Client.Contracts.Comments;

public record GetCommentsByRecyclingApplicationItemResponse(
    ImmutableArray<CommentResponse> Comments);