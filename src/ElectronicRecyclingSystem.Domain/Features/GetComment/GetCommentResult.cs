using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Domain.Features.GetComment;

public record GetCommentResult(
    Comment? Comment,
    User? User);